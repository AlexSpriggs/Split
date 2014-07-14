using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Targets : MonoBehaviour, IReceiver<Target>
{
	private List<Target> targetsLeft = new List<Target>();
	private List<Target> targetsRight = new List<Target>();
	private bool intersect = false;

	private int intersectCount = 0;
	private int maxIntersectCount;

	private List<Cubes> cubes = new List<Cubes>();
	private List<ResetRotationButton> resetRotationButtons = new List<ResetRotationButton>();
	private List<RotationButton> rotationButtons = new List<RotationButton>();

	void Start () 
	{
		targetsLeft.AddRange(assignTargets("LeftWorld"));
		targetsRight.AddRange(assignTargets("RightWorld"));

		maxIntersectCount = targetsLeft.Count;

		cubes.AddRange(transform.GetComponentsInChildren<Cubes>());

		for (int i = 0; i < transform.childCount; i++)
		{
			resetRotationButtons.Add
				(
					transform.GetChild(i).GetComponentInChildren<ResetRotationButton>()
				);
			rotationButtons.AddRange
				(
					transform.GetChild(i).GetComponentsInChildren<RotationButton>()
				);
		}
		

		SubScribe();
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
	
	public void HandleMessage(Telegram<Target> telegram)
	{
		if(telegram.Source != null)
		{
			if (telegram.Source.GetType() == typeof(Target))
			{
				if (BoundsCheck(telegram.Target))
				{
					Debug.Log("Cubes interset");
					saveState();

					foreach (ResetRotationButton resetRotationButton in resetRotationButtons)
					{
						MessageDispatcher.Instance.DispatchMessage(new ButtonTelegram(resetRotationButton));
					}

					foreach (RotationButton rotationButton in rotationButtons)
					{
						MessageDispatcher.Instance.DispatchMessage(new ButtonTelegram(rotationButton));
					}
				}
			}
		}
	}

	//Trying to make generic foreach loop based on button type passed in.
	//private void sendButtonMessaage(List<ButtonBase> buttonBases)
	//{
	//	foreach (typeof(buttonBases.GetType()) buttonBase in buttonBases)
	//	{
		
	//	}
	//}

	private void saveState()
	{
		foreach (Cubes cube in cubes)
		{
			cube.SaveState();
		}
	}

	private bool BoundsCheck(Target target)
	{
		switch(target.gameObject.tag)
		{
			case "LeftWorld":
				intersect = rightWorldBounds(target);
				break;
			case "RightWorld":
				intersect = leftWorldBounds(target);
				break;
		}
			
		return intersect;
	}

	private bool rightWorldBounds(Target target)
	{
		int prevIntersectCount = intersectCount;
		foreach (Target targetRight in targetsRight)
		{
			if (targetRight.RendererBounds.Intersects(target.RendererBounds))
			{
				intersectCount++;
				break;
			}
		}

		if (prevIntersectCount == intersectCount)
		{
			intersectCount = 0;
			intersect = false;
		}

		if (intersectCount == maxIntersectCount)
			intersect = true;

		return intersect;
	}

	private bool leftWorldBounds(Target target)
	{
		int prevIntersectCount = intersectCount;
		foreach (Target targetLeft in targetsLeft)
		{
			if (targetLeft.RendererBounds.Intersects(target.RendererBounds))
			{
				intersectCount++;
				break;
			}
		}

		if (prevIntersectCount == intersectCount)
		{
			intersectCount = 0;
			intersect = false;
		}

		if (intersectCount == maxIntersectCount)
			intersect = true;

		return intersect;
	}

	public void SubScribe()
	{
		MessageDispatcher.Instance.SendMessageTarget +=
			new MessageDispatcher.SendMessageHandler<Telegram<Target>>(HandleMessage);
	}

	public void UnSubScribe()
	{
		throw new System.NotImplementedException();
	}
}
