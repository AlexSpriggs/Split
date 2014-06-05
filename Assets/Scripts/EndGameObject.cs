using UnityEngine;
using System.Collections;

public class EndGameObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			col.gameObject.GetComponent<OVRPlayerController>().enabled = false;
			col.gameObject.GetComponent<OVRGamepadController>().enabled = false;

			Application.LoadLevel("End");
		}
	}
}
