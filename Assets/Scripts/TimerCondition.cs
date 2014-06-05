using UnityEngine;
using System.Collections;

public class TimerCondition : MonoBehaviour {

	public float timerStart, timerEnd, effectLength;
	public float timerInterval;
	private Color originalFog;
	private float fogR,fogG,fogB, fogRIncr, fogGIncr,fogBIncr;

	private bool isRed, timerCanIncriment;

	//Camera[] cameras;

	Quaternion StumbleRotate, originalRotation;

	// Use this for initialization
	void Start () {

		timerEnd = 300;
		timerInterval = .75f;
		effectLength = 120f;
		StumbleRotate = Quaternion.AngleAxis(-30, this.transform.forward);
		originalFog = RenderSettings.fogColor;
		isRed = false;
		timerCanIncriment = true;
		setFogVariables();
		fogRIncr = (1 - fogR) / 60f;
		fogBIncr = fogB / 60f;
		fogGIncr = fogG / 60f;
		//cameras = Camera.allCameras;

	
	}
	
	// Update is called once per frame
	void Update () {

		if(timerCanIncriment)
			timerStart++;

		if(timerStart >=timerEnd){
			timerStart = 0;
			timerEnd *= timerInterval;
			originalRotation = this.transform.rotation;

			setFogVariables();
			if(!isRed)
				StartCoroutine("GoToRed");

			//RenderSettings.fogColor = Color.clear;


		}

		if(timerEnd <= 30f){
			Application.LoadLevel(0);

		}

		if(isRed)
			StartCoroutine("GoToBlue");
	
	}

	IEnumerator GoToRed(){
		timerCanIncriment=false;
		for(int i = 0; i < 60; i++){
			fogR += fogRIncr;
			fogG -= fogGIncr;
			fogB -= fogBIncr;
			RenderSettings.fogColor = new Color(fogR,
			                                    fogG,
			                                    fogB,
			                                    1f);
			yield return new WaitForFixedUpdate();
			
		}

		for(int i = 0; i < effectLength; ++i)
			yield return new WaitForFixedUpdate();

		isRed = true;
	}

	IEnumerator GoToBlue(){
		isRed = false;
		for(int i = 0; i < 60; i++){
			fogR -= fogRIncr;
			fogG += fogGIncr;
			fogB += fogBIncr;
			RenderSettings.fogColor = new Color(fogR,
			                                    fogG,
			                                    fogB,
			                                    1f);
			yield return new WaitForFixedUpdate();
			
		}
		timerCanIncriment = true;

	}

	void setFogVariables(){

		fogR = originalFog.r;
		fogG = originalFog.g;
		fogB = originalFog.b;


	}
}
