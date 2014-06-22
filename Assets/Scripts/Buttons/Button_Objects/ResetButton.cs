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
			Platforms platform = platformHolder.transform.GetChild(i).GetComponent<Platforms>();
			//platforms.Add(platform.gameObject);
			ResetTonePuzzle.Instance.Add(platform, platform.transform.position);
			//resetPositions.Add(new ResetPosition(platform, platform.transform.position));
		}
	}

	public override void Activate()
	{
		if (!Activated)
		{
			base.Activate();

			ResetTonePuzzle.Instance.Reset();
			//foreach (GameObject p in platforms)
			//{
			//	for (int i = 0; i < resetPositions.Count; i++)
			//	{
			//		if (resetPositions[i].Equals(p))
			//		{
			//			resetPositions[i].ResetToInitialPosition();
			//			break;
			//		}
			//	}
			//}
			
			ColorsShouldFlash();
		}
	}

	protected override void callCoroutine()
	{
		throw new System.NotImplementedException();
	}
}
