using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour {

	public GameObject endText;
	public GameObject startText;

	// Use this for initialization
	void Start () {
		endText.SetActive(false);
		startText.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= 2f)
		{
			startText.SetActive(false);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Debug.Log ("End");
			endText.SetActive(true);
		}
	}
}
