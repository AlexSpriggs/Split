using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResetButton : ButtonBase 
{
	private GameObject platformHolder;
	private List<ResetPosition> resetPositions = new List<ResetPosition>();
	private List<GameObject> platforms = new List<GameObject>();

	protected override void Start () 
	{
		base.Start();

		platformHolder = GameObject.Find("Platforms");
		for (int i = 0; i < platformHolder.transform.childCount; i++)
		{
			Platform platform = platformHolder.transform.GetChild(i).GetComponent<Platform>();
			//platforms.Add(platform.gameObject);
			ResetTonePuzzle.Instance.Add(platform, platform.transform.position);
			//resetPositions.Add(new ResetPosition(platform, platform.transform.position));
		}
	}

	public override void Activate()
	{
		if (!Activated && !Solution.Instance.Solved())
		{
			base.Activate();

			ResetTonePuzzle.Instance.Reset();
			
			ColorsShouldFlash();
		}
	}

	protected override void callCoroutine()
	{
		throw new System.NotImplementedException();
	}
}
