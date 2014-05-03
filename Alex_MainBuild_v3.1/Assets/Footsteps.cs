using UnityEngine;
using System.Collections;

public class Footsteps : MonoBehaviour {
	public AudioClip WalkForward;
	public bool keepPlaying;
	public bool firstPlay;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Forward
		if (Input.GetKeyDown (KeyCode.W))
		{
			firstPlay = true;
			audio.clip = WalkForward;
			if(!keepPlaying)
			StartCoroutine("PlayFootsteps");

			keepPlaying = true;
		}

		if (Input.GetKeyUp (KeyCode.W))
		{
			keepPlaying = false;
		}

		//Backwards
		if (Input.GetKeyDown (KeyCode.S))
		{
			firstPlay = true;
			audio.clip = WalkForward;
			if(!keepPlaying)
			StartCoroutine("PlayFootsteps");

			keepPlaying = true;
		}
		if (Input.GetKeyUp (KeyCode.S))
		{
			keepPlaying = false;
		}


		//Left
		if (Input.GetKeyDown (KeyCode.A))
		{
			firstPlay = true;
			audio.clip = WalkForward;
			if(!keepPlaying)
			StartCoroutine("PlayFootsteps");

			keepPlaying = true;
		}
		if (Input.GetKeyUp (KeyCode.A))
		{
			keepPlaying = false;
		}


		//Right
		if (Input.GetKeyDown (KeyCode.D))
		{
			firstPlay = true;
			audio.clip = WalkForward;
			if(!keepPlaying)
			StartCoroutine("PlayFootsteps");

			keepPlaying = true;
		}
		if (Input.GetKeyUp (KeyCode.D))
		{
			keepPlaying = false;
		}

	
	}

	IEnumerator PlayFootsteps()
	{
		if (firstPlay) 
		{
			yield return new WaitForSeconds (0.5f);
			firstPlay = false;
		}
		if (keepPlaying) 
		{
			audio.Play ();
		}
		yield return new WaitForSeconds (audio.clip.length);
		if(keepPlaying)
			StartCoroutine ("PlayFootsteps");
	}
}	