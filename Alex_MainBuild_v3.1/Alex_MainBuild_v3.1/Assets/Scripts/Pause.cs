using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pause : MonoBehaviour 
{

	Texture paused;
	bool gamePaused = false;
	Color guiColor = Color.white;
	Color pauseBox = Color.white;

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
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(gamePaused && Input.GetKeyDown(KeyCode.Escape))
		{
			Time.timeScale = 1.0f;
			gamePaused = false;
		}
		else if (!gamePaused && Input.GetKeyDown(KeyCode.Escape)) 
		{
			gamePaused = true;
			Time.timeScale = 0.0f;
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
			GUI.DrawTexture(new Rect(200, 200, 1000, 500), paused, ScaleMode.StretchToFill);
		}
	}
}
