using UnityEngine;
using System.Collections;

public class Resolution : MonoBehaviour {
	private float x;
	public float X { get { return x; } }
	private float y;
	public float Y { get { return y; } }
	private Vector2 resolution;
	public Vector2 CurrentResolution { get { return resolution; } }

	private bool check;

	private static Resolution instance;

	public static Resolution Instance
	{
		get {return instance ?? (instance = new GameObject("Resolution").AddComponent<Resolution>()); }
		set { instance = value; }
	}
	
	// Use this for initialization
	void Start () 
	{
		CorrectResolution();
	}

	public void CorrectResolution()
	{
		resolution = new Vector2(Screen.width, Screen.height);
		x = (float)((float)Screen.width / 960f);
		y = (float)((float)Screen.height / 600f);
	}
	// Update is called once per frame
	void Update () 
	{
		adjustScreenSize ();
	}

	private void adjustScreenSize ()
	{
		if (Screen.width != resolution.x || Screen.height != resolution.y) 
		{
			check = true;
			CorrectResolution ();
		}
		else
			check = false;
	}

	public bool AdjustScreenSize()
	{
		if(check)
			return true;
		else
			return false;
	}
}
