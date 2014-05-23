using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pause : MonoBehaviour 
{

	Texture paused;
	bool gamePaused = false;
	Color background = Color.white;
	Color pauseBox = Color.white;

    GameObject currentPlayerController;

	private List<GameObject> unityPlayerController = new List<GameObject>();

	private List<Camera> cameras = new List<Camera>();

	private GameObject[] camerasToAdd = new GameObject[2];
	private bool testCameras = true;

    bool[] selections = new bool[3] { false, false, false };
    bool[] prevSelection = new bool[3] { true, true, true };
    string[] texts = new string[3] { "Options", "How to Play", "Return to Main Menu." };

	private float x;
	private float y;

	void Start () 
	{
		background.a = .5f;
		pauseBox.a = .75f;
		paused = (Texture)Resources.Load("Paused");

		if (GameObject.FindGameObjectWithTag("Player").GetComponent<MouseLook>()) 
		{
            Debug.Log("Unity Controller attached");

			unityPlayerController.Add(GameObject.FindGameObjectWithTag("Player"));
			unityPlayerController.Add(GameObject.FindGameObjectWithTag("MainCamera"));
			unityPlayerController.Add(GameObject.FindGameObjectWithTag("MainCameraTwo"));
		}

        currentPlayerController = GameObject.FindGameObjectWithTag("Player");

		camerasToAdd = GameObject.FindGameObjectsWithTag("MainCamera");
		for (int i = 0; i < camerasToAdd.Length; i++) 
		{
			cameras.Add(camerasToAdd[i].GetComponent<Camera>());
		}

		Resolution.Instance.CorrectResolution();
		x = Resolution.Instance.X;
		y = Resolution.Instance.Y;
	}
	
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

	void OnGUI()
	{
        if (gamePaused)
        {
            firstPersonControllerPause();

            ovrPlayerControllerPause();
        }
	}

    private void ovrPlayerControllerPause()
    {
        if(currentPlayerController.name == "OVRPlayerController")
        {
            menuArtOVR();
            buttonsOVR();
        }
    }

    private void buttonsOVR()
    {
        GUILayout.BeginArea(new Rect(80 * x, 100 * y, 100 * x, 500 * y));
        GUILayout.BeginVertical();
        for (int i = 0; i < selections.Length; i++)
        {
            if (i > 0)
                GUILayout.Space(25 * y);
                    
            if (GUILayout.Toggle(selections[i], texts[i], GUI.skin.button, GUILayout.Height(100 * y))
                && prevSelection[i] != selections[i])
            {
                buttonSelection(selections, i);
            }
        }
        GUILayout.EndVertical();
        GUILayout.EndArea();

        GUILayout.BeginArea(new Rect(540 * x, 100 * y, 100 * x, 500 * y));
        GUILayout.BeginVertical();
        for (int i = 0; i < selections.Length; i++)
        {
            if (i > 0)
                GUILayout.Space(25 * y);

            if (GUILayout.Toggle(selections[i], texts[i], GUI.skin.button, GUILayout.Height(100 * y))
                && prevSelection[i] != selections[i])
            {
                buttonSelection(selections, i);
            }
        }
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

    private void menuArtOVR()
    {
        GUI.color = background;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), paused, ScaleMode.StretchToFill, true, 0);

        GUI.color = pauseBox;
        GUI.DrawTexture(new Rect(x * 50, y * 50, x * 400, y * 500), paused, ScaleMode.StretchToFill);
        GUI.DrawTexture(new Rect(x * 500, y * 50, x * 400, y * 500), paused, ScaleMode.StretchToFill);
    }

    private void firstPersonControllerPause()
    {
        if (currentPlayerController.name == "First Person Controller")
        {
            menuArt();
            buttons();
        }
    }

    private void buttons()
    {
        GUILayout.BeginArea(new Rect(120 * x, 150 * y, 100 * x, 500 * y));
        GUILayout.BeginVertical();
            
            for (int i = 0; i < selections.Length; i++)
			{
                if (i > 0)
                    GUILayout.Space(25 * y);

                if (GUILayout.Toggle(selections[i], texts[i], GUI.skin.button, GUILayout.Height(100 * y))
                    && prevSelection[i] != selections[i])
                {
                    buttonSelection(selections, i);
                }
			}
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

    private void buttonSelection(bool[] choice, int i)
    {
        for (int j = 0; j < choice.Length; j++)
        {
             choice[j] = j == i;
             if (j == i)
                 prevSelection[j] = true;
        }

        switch (i)
        {
            case 0:
                Debug.Log("Options selected");
                break;
            case 1:
                Debug.Log("How to play selected");
                break;
            case 2:
                Debug.Log("return to main menu selected");
                break;
            default:
                Debug.Log("Value bigger than available cases passed int buttonSelection method");
                break;
        }
    }

    private void menuArt()
    {
            GUI.color = background;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), paused, ScaleMode.StretchToFill, true, 0);

            GUI.color = pauseBox;
            GUI.DrawTexture(new Rect(x * 100, y * 50, x * 750, y * 500), paused, ScaleMode.StretchToFill);
    }
}
