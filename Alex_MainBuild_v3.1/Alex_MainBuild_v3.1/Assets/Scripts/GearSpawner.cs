using UnityEngine;
using System.Collections;

public class GearSpawner : MonoBehaviour, IObserver
{
	public GameObject GearToSpawn;
	bool spawnTheGear;
	private int gearCount = 0;

	WinCondition winCondition;
	// Use this for initialization
	void Start () 
	{
		if (GameObject.FindGameObjectWithTag("Player").name == "OVRPlayerController") 
			assignWinCondition("OVRPlayerController");
		else if(GameObject.FindGameObjectWithTag("Player").name == "First Person Controller")
			assignWinCondition("First Person Controller");

		winCondition.Attach(this);
	}

	private void assignWinCondition(string gameObjectName)
	{
		winCondition = GameObject.Find(gameObjectName).GetComponent<WinCondition>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		spawnGear();
	}

	private void spawnGear()
	{
		if (spawnTheGear  && gearCount < 1) 
		{
			Instantiate(GearToSpawn, gameObject.transform.position, Quaternion.identity);

			spawnTheGear = false;
			gearCount++;
		}
	}

	public void ObserverUpdate(object sender, object message)
	{
		if (sender is WinCondition && !spawnTheGear) 
		{
			spawnTheGear = (bool)message;

			winCondition.Detach(this);
		}
	}
}
