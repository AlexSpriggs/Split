using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WinCondition : MonoBehaviour, ISubject {
	
	public int PuzzlesCompleted = 0;
	
	public int NeededPuzzlesToWin;

	public GameObject endGameObject;

	public GameObject spotLight;

	private  List<IObserver> observers = new List<IObserver>();

	// Use this for initialization
	void Start () {
		endGameObject.GetComponent<MeshRenderer>().enabled = false;
		endGameObject.GetComponent<SphereCollider>().enabled = false;

		spotLight.GetComponent<Light>().enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(PuzzlesCompleted >= 1)
			Notify();	
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

	public void Attach(IObserver o)
	{
		observers.Add(o);
	}

	public void Detach(IObserver o)
	{
		observers.Remove(o);
	}

	public void Notify()
	{
		foreach (IObserver o in observers) 
		{
			o.ObserverUpdate(this, true);

		}
	}
}
