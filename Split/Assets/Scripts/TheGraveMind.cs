using UnityEngine;
using System.Collections;

public class TheGraveMind : MonoBehaviour {

	public int ObjectivesCompleted = 0;
	public GameObject FirstGoal;

	//public GameObject Obelisk1;
	//public GameObject Obelisk2;
	//public GameObject Obelisk3;
	//public GameObject Obelisk4;
	//public GameObject Obelisk5;
	//public GameObject Obelisk6;

	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad(gameObject);
		if (ObjectivesCompleted >= 1)
		{
			//Obelisk1 = GameObject.FindGameObjectWithTag("Obelisk1");
			//Obelisk2 = GameObject.FindGameObjectWithTag("Obelisk2");
			//Obelisk3 = GameObject.FindGameObjectWithTag("Obelisk3");
			//Obelisk4 = GameObject.FindGameObjectWithTag("Obelisk4");
			//Obelisk5 = GameObject.FindGameObjectWithTag("Obelisk5");
			//Obelisk6 = GameObject.FindGameObjectWithTag("Obelisk6");
			FirstGoal = GameObject.FindGameObjectWithTag("FirstGoal");
			Destroy(FirstGoal);
		}
		else
		{
			FirstGoal = GameObject.FindGameObjectWithTag("Fodder");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (ObjectivesCompleted == 6)
		{
			GameWin();
		}
		if (ObjectivesCompleted >= 1)
		{
			FirstGoal = GameObject.FindGameObjectWithTag("FirstGoal");
			Destroy(FirstGoal);
		}
		else
		{
			FirstGoal = GameObject.FindGameObjectWithTag("Fodder");
		}
	}

	void OnLevelWasLoaded(int level) 
	{

	}

	public void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (other.gameObject.GetComponent<PowerCoreInventory>().HasCore == true)
			{
				ObjectivesCompleted += 1;
				audio.Play();
				other.gameObject.GetComponent<PowerCoreInventory>().HasCore = false;
			}
		}
	}

	public void GameWin()
	{
		Application.LoadLevel(7);
	}

	//public void CoresInserted()
	//{
	//	if (ObjectivesCompleted >= 1)
	//	{
	//		Obelisk1.renderer.material.SetColor("_Color", Color.green);
	//		Debug.Log("meow");
	//	}
	//}

}
