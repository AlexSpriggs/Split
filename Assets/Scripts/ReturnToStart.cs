using UnityEngine;
using System.Collections;

public class ReturnToStart : MonoBehaviour {

	bool start = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown("Fire1")) 
		{
			Debug.Log("Fire");
			start = true;
		}

		if(start)
			Application.LoadLevel("TomLevel");
	}

	void OnGUI()
	{
		GUI.Toggle(new Rect((Screen.width / 2) + 100f, (Screen.height / 2) + 100f, 100f, 100f), start, "Start", GUI.skin.button);
		GUI.Toggle(new Rect((Screen.width / 2) - 300f, (Screen.height / 2) + 100f, 100f, 100f), start, "Start", GUI.skin.button);
	}
}
