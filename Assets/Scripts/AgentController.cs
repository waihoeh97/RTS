using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour {
	
	Transform target;
	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		StartCoroutine (PathingRoutine ());
	}

	IEnumerator PathingRoutine ()
	{
		while (true) 
		{
			yield return new WaitForSeconds (0.1f);

			// If has target, set navmeshagent to move towards it
			if (target)
			{
				agent.SetDestination (target.position);
			} 
			else 
			{
				// FInd a target with the tag target
				if (GameObject.FindGameObjectWithTag("Target"))
				{
					target = GameObject.FindGameObjectWithTag ("Target").transform;			
				}
			}	
		}
	}

	void OnDrawGizmos ()
	{
		if (agent == null) 
		{
			agent = GetComponent<NavMeshAgent> ();	
		}

		if (agent.hasPath) 
		{
			Gizmos.color = Color.red;
			for (int i = 0; i < agent.path.corners.Length - 1; i++) 
			{
				Gizmos.DrawLine (agent.path.corners [i], agent.path.corners [i + 1]);
			}
		}
	}
}
