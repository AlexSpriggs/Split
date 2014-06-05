using UnityEngine;
using System.Collections;

public class SceneSwitcher : MonoBehaviour {

	public int SceneNumber;

	// Use this for initialization
	void Start () {
	
	}
	
	public void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			Application.LoadLevel(SceneNumber);
		}

	}
}