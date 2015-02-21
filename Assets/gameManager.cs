using UnityEngine;
using System.Collections.Generic;
using FlockingManager;
using behaviours;

public class gameManager : MonoBehaviour {
	private GameObject viperLeader;
	private GameObject cylonLeader;
	private FlockingManager cylonMgr;
	private FlockingManager viperMgr;
	private List<GameObject> cylonSquad;
	private List<GameObject> viperSquad;
	private int squadSize =10;

	// Use this for initialization
	void Start () {

		viperLeader = (GameObject)Instantiate(Resources.Load ("viper"), Vector3.zero, Quaternion.identity);
		cylonLeader = (GameObject)Instantiate(Resources.Load ("cylonRaider"), Vector3.zero, Quaternion.AngleAxis(-90.0f,new Vector3(1,0,0)));


		cylonSquad = new List<GameObject> ();
		viperSquad = new List<GameObject> ();

		for (int i=0; i<squadSize; i++) 
		{
			GameObject squadMember = (GameObject)Instantiate(Resources.Load ("viper"), Vector3.zero, Quaternion.identity);
			viperSquad.Add(squadMember);

			squadMember = (GameObject)Instantiate(Resources.Load ("cylonRaider"), Vector3.zero, Quaternion.AngleAxis(-90.0f,new Vector3(1,0,0)));
			cylonSquad.Add(squadMember);
		}

		cylonMgr = new FlockingManager(cylonLeader,cylonSquad);
		cylonMgr.beginFlocking ();

		viperMgr = new FlockingManager (viperLeader, viperSquad);
		viperMgr.beginFlocking ();
	}

	// Update is called once per frame
	void Update () {

	}
}
