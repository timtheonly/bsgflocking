using UnityEngine;
using System.Collections.Generic;
using SteeringBehaviours;

public class gameManager : MonoBehaviour {
	private GameObject viperLeader;
	private GameObject cylonLeader;
	/*private FlockingManager cylonMgr;
	private FlockingManager viperMgr;
	private List<GameObject> cylonSquad;
	private List<GameObject> viperSquad;*/
	private int squadSize =10;

	// Use this for initialization
	void Start () {

		cylonLeader = (GameObject)Instantiate(Resources.Load ("boid"), Vector3.zero, Quaternion.identity);
		cylonLeader.GetComponent<Steering> ().targetPos = new Vector3 (0, 50, 200.0f);
		cylonLeader.GetComponent<Steering> ().enableBehaviour (steeringBehaviours.behaviours.arrive);
	}

	// Update is called once per frame
	void Update () {

	}
}
