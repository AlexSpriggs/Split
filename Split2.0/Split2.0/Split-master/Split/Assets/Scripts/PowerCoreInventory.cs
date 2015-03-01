using UnityEngine;
using System.Collections;

public class PowerCoreInventory : MonoBehaviour {

	public bool HasCore = false;
	public GameObject theGravemind;
	public AudioClip goalsound;

	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad(gameObject);
		theGravemind = GameObject.FindGameObjectWithTag("GraveMind");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "GoalObject" || other.gameObject.tag == "FirstGoal")
		{
			HasCore = true;
			audio.PlayOneShot (goalsound, 1f);
			Destroy(other.gameObject);
		}

		//if (other.gameObject.tag == "SceneSwitcher")
		//{
		//	if (HasCore == true)
		//	{
		//	HasCore = false;
		//	theGravemind.GetComponent<TheGraveMind>().ObjectivesCompleted += 1;
		//	}
		//}
	}
}
