using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {

	public bool gateOpen = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Debug.Log ("Gate Open");
			gateOpen = true;
		}
	}
}
