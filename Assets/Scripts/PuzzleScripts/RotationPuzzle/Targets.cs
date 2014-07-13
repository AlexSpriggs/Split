using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Targets : MonoBehaviour 
{
	private List<Target> targetsLeft = new List<Target>();
	private List<Target> targetsRight = new List<Target>();
	private bool intersect = false;

	void Start () 
	{
		targetsLeft.AddRange(assignTargets("LeftWorld"));
		targetsRight.AddRange(assignTargets("RightWorld"));
	}
	
	private List<Target> assignTargets(string layer)
	{
		GameObject[] g = GameObject.FindGameObjectsWithTag(layer);
		List<Target> t = new List<Target>();
		foreach (GameObject go in g)
		{
			t.Add(go.GetComponent<Target>());
		}
		return t;
	}
	
	void Update () // TODO Change to Targets Send Message
	{
		if (BoundsCheck())
			Debug.Log("Cubes interset");
	}

	private bool BoundsCheck()
	{
		foreach (Target targetLeft in targetsLeft)
		{
			foreach (Target targetRight in targetsRight)
			{
				if (targetLeft.RendererBounds.Intersects(targetRight.RendererBounds))
				{
					intersect = true;
					break;
				}
				else
				{
					intersect = false;
				}
			}
		}

		return intersect;
	}
}
