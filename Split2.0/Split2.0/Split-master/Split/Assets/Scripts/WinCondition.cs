using UnityEngine;
using System.Collections;

public class WinCondition : MonoBehaviour {
	
	public int PuzzlesCompleted = 0;
	
	public int NeededPuzzlesToWin;

	public GameObject endGameObject;

	public GameObject spotLight;

	// Use this for initialization
	void Start () {
		endGameObject.GetComponent<MeshRenderer>().enabled = false;
		endGameObject.GetComponent<SphereCollider>().enabled = false;

		spotLight.GetComponent<Light>().enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		

	
	}
	
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "PuzzleAward")
		{
			gameObject.audio.Play();
			PuzzlesCompleted++;

			if(PuzzlesCompleted == NeededPuzzlesToWin)
				EndGame();
		}
	}
	
	public void EndGame()
	{
		endGameObject.GetComponent<MeshRenderer>().enabled = true;
		endGameObject.GetComponent<SphereCollider>().enabled = true;

		spotLight.GetComponent<Light>().enabled = true;

	}
}
