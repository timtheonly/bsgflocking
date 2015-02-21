using System;
using UnityEngine;
using System.Collections.Generic;
using behaviours;

public class FlockingManager
{
	public GameObject leader;
	public List<GameObject> squad;
	public FlockingManager (GameObject leader,List<GameObject> squad)
	{
		this.leader = leader;
		this.leader.GetComponent<SteeringBehaviours> ().isLeader = true;

		this.squad = squad;

	}

	public void beginFlocking()
	{
		leader.GetComponent<SteeringBehaviours>().enableBehaviour(behaviours.flock);
		foreach (GameObject member in squad) 
		{
			member.GetComponent<SteeringBehaviours>().leader = leader;
			member.GetComponent<SteeringBehaviours>().enableBehaviour(behaviours.flock);
		}
	}

	public void stopFlocking()
	{
		leader.GetComponent<SteeringBehaviours>().enableBehaviour(behaviours.flock);
		foreach (GameObject member in squad) 
		{
			member.GetComponent<SteeringBehaviours>().leader = null;
			member.GetComponent<SteeringBehaviours>().disableBehaviour(behaviours.flock);
		}

	}
}