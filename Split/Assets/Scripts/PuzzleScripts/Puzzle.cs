using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Puzzle : MonoBehaviour 
{
	private List<GameObject> gameObjectsInScene = new List<GameObject>();

	void Start () 
	{
		if (gameObjectsInScene == null)
		{
			for (int i = 0; i < gameObject.transform.childCount; i++)
			{
				gameObjectsInScene.Add(gameObject.transform.GetChild(i).gameObject);
			}
		}
	}

	public Puzzle Register()
	{
		return this;
	}
}
