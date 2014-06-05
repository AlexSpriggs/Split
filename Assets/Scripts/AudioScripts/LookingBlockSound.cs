using UnityEngine;
using System.Collections;

public class LookingBlockSound : MonoBehaviour {

	// Use this for initialization
	void Start () {

		//StartCoroutine("PlaySound");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator PlaySound()
	{
		yield return new WaitForSeconds(5f);

		gameObject.audio.Play();

		StartCoroutine("PlaySound");
	}
}
