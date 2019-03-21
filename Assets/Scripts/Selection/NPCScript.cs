using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCScript : MonoBehaviour , IBaseNPC
{
	public bool isSelected = false;
	public GameObject selectionRing;
	public NavMeshAgent agent;
	public Vector3 MoveTo;
	public bool notSet = false;

	public Transform carPointer;
	public Movement car;
	public float minMoveRange;
	public SpriteRenderer cursor;

	// Use this for initialization
	void Start () 
	{
		agent = gameObject.GetComponent<NavMeshAgent>();
	}

	public void MoveUnit (Vector2 target)
	{
		transform.position = target;
	}

	void SelectionPrimary ()
	{
		if (selectionRing.activeSelf == true)
		{
			isSelected = true;
		}

		if (Input.touchCount == 1)
		{
			if (isSelected)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit, 100))
				{
					if (hit.collider.tag == "Floor")
					{
						Debug.DrawLine(ray.origin, hit.point);

						carPointer.position = new Vector3(hit.point.x, carPointer.position.y, hit.point.z);

						if (Vector3.Distance(carPointer.position, car.transform.position) > minMoveRange)
						{
							car.moving = true;
							cursor.enabled = true;
						}
					}
				}	
			}
		}
	}

	void SelectionSecondary ()
	{
		if (isSelected && notSet)
		{
			notSet = false;
			agent.SetDestination(MoveTo);
		}
	}

	void Select (int x)
	{
		isSelected = true;
	}

	void Deselect (int x)
	{
		isSelected = false;
	}

	void Destination (Vector3 d)
	{
		MoveTo = d;
		notSet = true;
	}

	// Update is called once per frame
	void Update () 
	{
		SelectionPrimary();
		//SelectionSecondary();
	}
}
