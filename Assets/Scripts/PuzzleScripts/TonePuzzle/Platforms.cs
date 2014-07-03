using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Platforms : MonoBehaviour 
{
	private List<Platform> platform = new List<Platform>();

	void Start () 
	{
		platform.AddRange(gameObject.GetComponentsInChildren<Platform>());
	}
	
	// Update is called once per frame
	void Update () 
	{
		foreach (Platform p in platform)
		{
			if (Solution.Instance.Solved() && p.GetMovePlatform.Moving)
				p.SaveState();
		}
	}
}
