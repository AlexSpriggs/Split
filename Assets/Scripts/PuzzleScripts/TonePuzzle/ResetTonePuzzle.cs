using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResetTonePuzzle  
{
	private static ResetTonePuzzle instance;
	public static ResetTonePuzzle Instance
	{
		get
		{
			return instance ?? (instance = new ResetTonePuzzle());
		}
	}

	private List<ResetPosition> resetPositions = new List<ResetPosition>();
	private List<GameObject> platforms = new List<GameObject>();

	public void Add(Platforms platform, Vector3 initialPosition)
	{
		AddGameObject(platform.gameObject);
		resetPositions.Add(new ResetPosition(platform, initialPosition));
	}

	private void AddGameObject(GameObject gameObject)
	{
		platforms.Add(gameObject);
	}

	public void Reset()
	{
		foreach (GameObject p in platforms)
		{
			for (int i = 0; i < resetPositions.Count; i++)
			{
				if (resetPositions[i].Equals(p))
				{
					resetPositions[i].ResetToInitialPosition();
					break;
				}
			}
		}
	}
}
