using UnityEngine;
using System.Collections;

public class ObjectiveScript : MonoBehaviour {

	public GameObject Player;

	bool DoOnce = true;

	// Use this for initialization
	void Start () {

		Player = GameObject.FindGameObjectWithTag("Player");

		StartCoroutine("StartObjective");
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Player.GetComponent<WinCondition>().PuzzlesCompleted == 4)
		{
			if(DoOnce)
				StartCoroutine("StartEndGameObjective");
		}
	
	}

	IEnumerator StartObjective()
	{
		yield return new WaitForSeconds(10);

		gameObject.GetComponent<MeshRenderer>().enabled = false;
	}

	IEnumerator StartEndGameObjective()
	{
		gameObject.GetComponent<TextMesh>().text = "Find the center of the forest.";
		gameObject.GetComponent<MeshRenderer>().enabled = true;

		yield return new WaitForSeconds(10);

		gameObject.GetComponent<MeshRenderer>().enabled = false;
	}
}
