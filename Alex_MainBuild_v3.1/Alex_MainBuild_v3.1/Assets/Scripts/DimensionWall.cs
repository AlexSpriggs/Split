using UnityEngine;
using System.Collections;

public class DimensionWall : MonoBehaviour {

    public int layer;
	// Use this for initialization
	void Awake () {
        layer = gameObject.layer;
	}
	
	// Update is called once per frame
	void Update () {
        layer = gameObject.layer;
	}

	public void Switch()
	{
		if(gameObject.layer == 8)
			gameObject.layer = 9;
		else
			gameObject.layer = 8;
	}
}
