using UnityEngine;
using System.Collections;

public class Gear : MonoBehaviour {
	
	private MeshRenderer meshRenderer;

	private Vector3 moveDirectionDown = new Vector3(0, -1);
	private float moveSpeed = 2f;
	// Use this for initialization
	void Start () 
	{
		//For testing how object movement feels for larger assets.
		//gameObject.transform.localScale = new Vector3(100, 100, .5f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gameObject.transform.position.y > 18)
			gameObject.transform.position += (moveDirectionDown * Time.deltaTime * moveSpeed);

		gameObject.transform.Rotate(Vector3.right);
		gameObject.transform.Rotate(Vector3.down);
	}
}
