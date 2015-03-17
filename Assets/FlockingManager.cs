using System;
using UnityEngine;
using System.Collections.Generic;
using SteeringBehaviours;

public class FlockingManager
{
	public GameObject leader;
	public List<GameObject> squad;
	public FlockingManager (GameObject leader,List<GameObject> squad)
	{
		this.leader = leader;
		this.leader.GetComponent<Steering> ().isLeader = true;

		this.squad = squad;

	}

	public void beginFlocking()
	{
		leader.GetComponent<Steering>().enableBehaviour(steeringBehaviours.behaviours.flock);
		foreach (GameObject member in squad) 
		{
			member.GetComponent<Steering>().leader = leader;
			member.GetComponent<Steering>().enableBehaviour(steeringBehaviours.behaviours.flock);
		}
	}

	public void stopFlocking()
	{
		leader.GetComponent<Steering>().enableBehaviour(steeringBehaviours.behaviours.flock);
		foreach (GameObject member in squad) 
		{
			member.GetComponent<Steering>().leader = null;
			member.GetComponent<Steering>().disableBehaviour(steeringBehaviours.behaviours.flock);
		}

	}
}