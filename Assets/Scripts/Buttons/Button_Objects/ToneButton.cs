using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Tones { ONE, TWO, THREE, FOUR, FIVE, SIX, SEVEN };
public class ToneButton : ButtonBase 
{
	public Tones Tone;
	private List<PlatformTelegram> platformTelegrams = new List<PlatformTelegram>();

	public List<Vector3> MoveDistances;

	public List<GameObject> targetPlatforms;

	protected override void Start()
	{
		highLightColor = Color.green;

		for (int i = 0; i < 2; i++)
		{
			if (targetPlatforms[i] != null)
			{
				Platforms platform = targetPlatforms[i].GetComponent<Platforms>();
				platformTelegrams.Add(new PlatformTelegram(platform, MoveDistances[i]));
			}
		}

		base.Start();
	}

	public override void Activate()
	{
		if (!Activated && !Solution.Instance.Solved(Tone))
		{
			base.Activate();

			if (Solution.Instance.Correct(Tone))
			{
				Debug.Log("Tone: " + Tone.ToString());

				foreach (PlatformTelegram platformMessage in platformTelegrams)
				{
					MessageDispatcher.Instance.DispatchMessage(platformMessage);
				}
			}
			else
			{
				Solution.Instance.Reset();
				ResetTonePuzzle.Instance.Reset();
			}
			ColorsShouldFlash();
		}
	}

	protected override void callCoroutine()
	{
		throw new System.NotImplementedException();
	}

	public override void HandleMessage(Telegram<ButtonBase> telegram)
	{
		throw new System.NotImplementedException();
	}
}
