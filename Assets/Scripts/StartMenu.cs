using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	Color startBox = Color.white;

	bool buttonSelection = false;
	bool GUIOn = true;

	Texture start;

	public Camera[] cameras;
	Rect startRect;
	// Use this for initialization
	void Start () 
	{
		startBox.a = .75f;
		start = (Texture)Resources.Load("Paused"); //Paused is name of texture

		startRect = new Rect(0, 0, Screen.width, Screen.height);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Application.LoadLevel(1);
		if (Input.GetButtonDown("Fire1")) 
		{
			if(buttonSelection)
				buttonSelection = false;
			else if(!buttonSelection)
			{
				buttonSelection = true;
				for (int i = 0; i < cameras.Length; i++) 
				{
					gameObject.SetActive(false);
					GUIOn = false;
				}
			}
				
		}
	}

	void OnGUI()
	{
		if (GUIOn) 
		{
			GUI.color = startBox;
			GUI.DrawTexture(startRect, start, ScaleMode.StretchToFill, true, 0);

			GUI.Toggle(new Rect((Screen.width / 2) + 100f, (Screen.height / 2) + 100f, 100f, 100f), buttonSelection, "Start", GUI.skin.button);
			GUI.Toggle(new Rect((Screen.width / 2) - 300f, (Screen.height / 2) + 100f, 100f, 100f), buttonSelection, "Start", GUI.skin.button);
		}

	}

}
