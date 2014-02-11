using UnityEngine;
using System.Collections;

public class SwitchCamera : MonoBehaviour {

	public Camera CameraOne;

	public Camera CameraTwo;

	protected bool CameraOneOn;

	// Use this for initialization
	void Start () {

		CameraOne.enabled = true;
		CameraTwo.enabled = false;

		CameraOneOn = true;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyUp(KeyCode.R))
		{
			if(CameraOneOn == true)
			{
				CameraOne.enabled = false;
				CameraTwo.enabled = true;
				CameraOneOn = false;
			}
			else
			{
				CameraOne.enabled = true;
				CameraTwo.enabled = false;
				CameraOneOn = true;
			}
		}

	}
}
