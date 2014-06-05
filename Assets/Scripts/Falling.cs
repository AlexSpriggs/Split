using UnityEngine;
using System.Collections;

public class Falling : MonoBehaviour {

	public Vector3 StartPosition;

	// Use this for initialization
	void Start () {

		StartPosition = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "FallZone")
		{
			transform.position = new Vector3(StartPosition.x, StartPosition.y + 140, StartPosition.z);
		}
	}
}
