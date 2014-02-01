using UnityEngine;
using System.Collections;

public class DimensionWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Switch()
	{
		if(gameObject.layer == 8)
			gameObject.layer = 9;
		else
			gameObject.layer = 8;
	}
}
