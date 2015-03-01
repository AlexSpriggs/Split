using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ForwardDirection : MonoBehaviour 
{
	private Ray ray;
	private float distance = 20f;

	private RaycastHit hitInfo;

	public Transform ForwardPosition { get { return transform; } }

	private List<Camera> cameras = new List<Camera>();

	public ButtonBase Button { get; private set; }
	// Use this for initialization
	void Start () 
	{
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
		ray.origin = transform.position;
		ray.direction = transform.forward;
		Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
		
	}

	public void Hit()
	{
		Physics.SphereCast(ray, 1f, out hitInfo, distance);
		//Physics.Raycast(ray.origin, ray.direction, out hitInfo, distance);
		if (hitInfo.collider != null)
		{
			if (hitInfo.collider.gameObject.tag == "Button")
			{
				if(Button != null)
				{
					if (!Button.Equals(hitInfo.collider.gameObject.GetComponent<ButtonBase>()))
						Button.DeSelect();
				}

				Button = hitInfo.collider.gameObject.GetComponent<ButtonBase>();
				if(!Button.Activated && !Button.Locked)
					Button.HighLight();
			}
			else if(Button != null)
			{
				if(!Button.Activated && !Button.Locked)
					Button.DeSelect();
				Button = null;
			}
				
		}
		else if(Button != null)
		{
			if(!Button.Activated && !Button.Locked)
				Button.DeSelect();
			Button = null;
		}
	}
}
