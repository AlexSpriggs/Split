using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwitchDimension : MonoBehaviour {

	public List<GameObject> MyWalls;

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
			if(!audio.isPlaying)
				audio.Play();
			foreach (GameObject go in MyWalls)
			{
                go.GetComponent<DimensionWall>().Switch();
			}
		}
	}
}
