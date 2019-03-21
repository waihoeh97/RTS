using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private GameObject selectedUnit;

	public Transform car;
	public float speed;

	// Use this for initialization
	void Start () {
		
	}

	void RayCast ()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast(ray, out hit))
		{
			if (hit.transform.tag == "Player" && Input.GetMouseButtonDown(0))
			{
				if (selectedUnit != null)
				{
					selectedUnit.SendMessage("Deselect", 1);
				}
				selectedUnit = hit.transform.gameObject;
				selectedUnit.SendMessage("Select", 1);
			}
			if (hit.transform.tag == "Floor" && Input.GetMouseButtonDown(1))
			{
				selectedUnit.SendMessage("Destination", hit.point);
			}
			if (hit.transform.tag == "Floor" && Input.GetMouseButtonDown(0))
			{
				selectedUnit.SendMessage("Deselect", 1);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position, car.position, speed * Time.deltaTime);
		//RayCast();
	}
}
