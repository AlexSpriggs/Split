using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ForwardDirection : MonoBehaviour 
{
	private Ray ray;
	private float distance = 20f;

	private List<Vector3> viewCone = new List<Vector3>();

	private RaycastHit hitInfo;

	public Transform ForwardPosition { get { return transform; } }

	private List<Camera> cameras = new List<Camera>();

	public ButtonBase Button { get; private set; }
	// Use this for initialization
	void Start () 
	{
		viewCone.Add(gameObject.transform.position + new Vector3(0f, 2f, distance));
		viewCone.Add(gameObject.transform.position + new Vector3(0f, -2f, distance));
		viewCone.Add(gameObject.transform.position + new Vector3(2f, 0f, distance));
		viewCone.Add(gameObject.transform.position + new Vector3(-2f, 0f, distance));
		Camera[] cameraArray = GameObject.FindObjectsOfType<Camera>();
		cameras.AddRange(cameraArray);

		Vector3 averageCameraPosition = new Vector3();
		foreach (Camera c in cameras)
		{
			averageCameraPosition += c.transform.position;
		}

		gameObject.transform.position = averageCameraPosition / cameras.Count;
	}
	
	// Update is called once per frame
	void Update () 
	{
		for (int i = 0; i < viewCone.Count; i++)
		{
			Vector3 dir = gameObject.transform.position - gameObject.transform.forward;
			dir = Quaternion.Euler(gameObject.transform.up) * dir;
			viewCone[i] += dir + gameObject.transform.forward;
			Debug.DrawLine(gameObject.transform.position, viewCone[i], Color.blue);
		}
		ray.origin = transform.position;
		ray.direction = transform.forward;
		Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
	}

	public void Hit()
	{
		Physics.Raycast(ray.origin, ray.direction, out hitInfo, distance);
		if (hitInfo.collider != null)
		{
			if (hitInfo.collider.gameObject.tag == "Button")
			{
				Button = hitInfo.collider.gameObject.GetComponent<ButtonBase>();
				if(!Button.Activated)
					Button.HighLight();
			}
			else if(Button != null)
			{
				if(!Button.Activated)
					Button.DeSelect();
				Button = null;
			}
				
		}
		else if(Button != null)
		{
			if(!Button.Activated)
				Button.DeSelect();
			Button = null;
		}
	}
}
