using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour {

	public Gate gate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gate.gateOpen == true)
		{
			if (transform.position.y <= 8.0f)
			{
				Debug.Log ("Gate Opened");
				transform.Translate(Vector3.up * Time.deltaTime * 3f, Space.World);	
			}
		}
	}
}
