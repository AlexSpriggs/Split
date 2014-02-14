using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pause : MonoBehaviour 
{

	Texture paused;
	bool gamePaused = false;
	Color guiColor = Color.white;
	Color pauseBox = Color.white;

	private List<GameObject> unityPlayerController = new List<GameObject>();

	private List<Camera> cameras = new List<Camera>();

	private GameObject[] camerasToAdd = new GameObject[2];
	private bool testCameras = true;

	private float x;
	private float y;
//	public List<GameObject> gameobjects = new List<GameObject>();
//	private List<MonoBehaviour> scripts = new List<MonoBehaviour>();
	// Use this for initialization
	void Start () 
	{
//		Object[] objects = Resources.FindObjectsOfTypeAll(typeof(GameObject));
//		for (int i = 0; i < objects.Length; i++) 
//		{
//			if(((GameObject)objects[i]).activeInHierarchy && !((GameObject)objects[i]).GetComponent<Pause>()
//			   && ((GameObject)objects[i]).GetComponent<MonoBehaviour>())
//			{
//				scripts.Add(((GameObject)objects[i]).GetComponent<MonoBehaviour>());
//				if(((GameObject)objects[i]).GetComponent<OVRPlayerController>())
//					Debug.Log("OVRPlayerController added");
//			}
//				
//		}
		guiColor.a = .5f;
		pauseBox.a = .75f;
		paused = (Texture)Resources.Load("Paused");

		if (GameObject.FindGameObjectWithTag("Player").GetComponent<MouseLook>()) 
		{
			unityPlayerController.Add(GameObject.FindGameObjectWithTag("Player"));
			unityPlayerController.Add(GameObject.FindGameObjectWithTag("MainCamera"));
			unityPlayerController.Add(GameObject.FindGameObjectWithTag("MainCameraTwo"));
		}
			

		camerasToAdd = GameObject.FindGameObjectsWithTag("MainCamera");
		for (int i = 0; i < camerasToAdd.Length; i++) 
		{
			cameras.Add(camerasToAdd[i].GetComponent<Camera>());
		}

		Resolution.Instance.CorrectResolution();
		x = Resolution.Instance.X;
		y = Resolution.Instance.Y;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (testCameras) 
		{
			Debug.Log("Cameras in cameras: " + cameras.Count);
			testCameras = false;
		}

		if(gamePaused && Input.GetKeyDown(KeyCode.Escape))
		{
			deactivateUnityMouseLook (true);

			changeCameraType (false);
			Time.timeScale = 1.0f;
			gamePaused = false;
		}
		else if (!gamePaused && Input.GetKeyDown(KeyCode.Escape)) 
		{
			deactivateUnityMouseLook (false);

			changeCameraType (true);
			gamePaused = true;
			Time.timeScale = 0.0f;
		}
	}

	void deactivateUnityMouseLook (bool enable)
	{
		if (unityPlayerController.Count > 0)
			foreach (GameObject controller in unityPlayerController)
				controller.GetComponent<MouseLook>().enabled = enable;
	}

	void changeCameraType (bool ortho)
	{
		foreach (Camera cameraElement in cameras) {
			cameraElement.orthographic = ortho;
		}
	}

//	private void changeState (bool state)
//	{
//		foreach (MonoBehaviour script in scripts) 
//		{
//			if(script is OVRPlayerController)
//				Debug.Log("OVR controller is disabled");
//
//			script.enabled = state;
//		}
//	}

	void OnGUI()
	{
		if(gamePaused)
		{
			GUI.color = guiColor;
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), paused, ScaleMode.StretchToFill, true, 0);

			GUI.color = pauseBox;
			GUI.DrawTexture(new Rect( x * 100, y * 50, x * 750, y * 500), paused, ScaleMode.StretchToFill);
		}
	}
}
