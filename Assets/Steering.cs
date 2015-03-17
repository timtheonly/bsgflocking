using UnityEngine;
using System.Collections;
using steeringBehaviours;

namespace SteeringBehaviours
{
	public class Steering : MonoBehaviour {

		behaviours behaviourMask;

		private Vector3 force, velocity, acceleration;

		private float _mass =1.0f;
		public float mass{
			get{return _mass;}
			set{this._mass = value;}
		}

		private float _maxSpeed = 50.0f;
		public float maxSpeed{
			get{return _maxSpeed;}
			set{this._maxSpeed = value;}
		}
		private Vector3 _offset;
		public Vector3 offset{
			get{return _offset;}
			set{ this._offset = value;}
		}

		private Vector3 _targetPos;
		public Vector3 targetPos{
			set{this._targetPos = value;}
			get{return _targetPos;}
		}

		private GameObject _leader;
		public GameObject leader{
			set{this.leader = value;}
		}

		private bool _isLeader = false;
		public bool isLeader{
			set { this._isLeader = value;}
		}

		// Use this for initialization
		void Start () {
			force = Vector3.zero;
			acceleration = Vector3.zero;
			velocity = Vector3.zero;
		}
		
		// Update is called once per frame
		void Update () {
			if (isEnabled (behaviours.seek)) {
				force = seek();
			} else if (isEnabled (behaviours.avoid)) {
				force = avoid ();
			} else if (isEnabled (behaviours.flee)) {
				force = flee ();
			} else if (isEnabled (behaviours.persuit)) {
				force = persuit ();
			} /*else if (isEnabled (behaviours.flock)) {
				force = flock ();
			}*/ else if (isEnabled (behaviours.evade)) {
				force = evade ();
			}else if(isEnabled (behaviours.arrive)){
				force = arrive ();
			}


			acceleration = force / mass;
			velocity += acceleration * Time.deltaTime;
			transform.position += velocity * Time.deltaTime;

			float speed = velocity.magnitude;

			if (speed > Mathf.Epsilon) {
			
				transform.forward = velocity;
				transform.forward.Normalize();
			}
		}
		
	#region behaviour management
		public void enableBehaviour(behaviours behaviour)
		{
			behaviourMask |= behaviour;
		}

		public void disableBehaviour(behaviours behaviour)
		{
			behaviourMask &= ~behaviour;
		}

		public bool isEnabled(behaviours behaviour)
		{
			//Debug.Log(behaviour.ToString()+ "enabled");
			return(behaviourMask & behaviour) != 0;
		}

		public void disableAllBehaviours()
		{
			behaviourMask = behaviours.none;
		}

		private Vector3 seek()
		{
			Vector3 desired = Vector3.Normalize (targetPos - transform.position) * maxSpeed;
			return (desired - velocity);
		}

		private Vector3 avoid()
		{
			return Vector3.zero;
		}

		private Vector3 flee()
		{
			Vector3 desired = Vector3.Normalize (transform.position - targetPos) * maxSpeed;
			return (desired - velocity);
		}

		private Vector3 persuit()
		{
			return Vector3.zero;
		}

		private Vector3 evade()
		{
			return Vector3.zero;
		}

		private Vector3 flock()
		{
			return Vector3.zero;
		}

		private Vector3 arrive()
		{
			Vector3 toTarget = targetPos - transform.position;

			float distance = toTarget.magnitude;

			//stop if we're close enough
			if (distance < Mathf.Epsilon) {
				return Vector3.zero;
			}

			//radius at which we start slowing;
			float slowingSpace = 8.0f;
			//magic number !!!!!!!
			float decelerationTweker = 12.3f;

			float ramped = maxSpeed * (distance / (slowingSpace * decelerationTweker));

			//don't exceeed maxspeed;
			float clamped = Mathf.Min (ramped, maxSpeed);

			Vector3 desired = clamped * (toTarget / distance);

			return desired - velocity;
		}
	#endregion
	}
}