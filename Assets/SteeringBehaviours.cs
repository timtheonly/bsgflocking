using UnityEngine;
using System.Collections;
using behaviours;

public class SteeringBehaviours : MonoBehaviour {

	int behaviourMask =0;

	private Vector3 force, velocity, acceleration;
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

	}
	
	// Update is called once per frame
	void Update () {
		this.transform += velocity;
	}
	
#region behaviour management
	public void enableBehaviour(behaviours behaviour)
	{
		behaviourMask &= behaviour;
	}

	public void disableBehaviour(behaviours behaviour)
	{
		behaviourMask &= ~behaviour;
	}

	public bool isEnabled(behaviours behaviour)
	{
		return(behaviourMask & behaviour) != 0;
	}

	public void disableAllBehaviours()
	{
		behaviourMask = 0;
	}
#endregion
}
