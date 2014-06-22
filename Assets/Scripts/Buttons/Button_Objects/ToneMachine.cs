using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ToneMachine : ButtonBase 
{
	private List<Tones> tones = new List<Tones>() 
								{ 
									Tones.ONE, 
									Tones.THREE,
									Tones.FIVE,
									Tones.TWO,
									Tones.SIX
								};
	protected override void Start()
	{
		highLightColor = Color.blue;

		Solution.Instance.AddRange(tones);

		base.Start();
	}

	public override void Activate()
	{
		if (!Activated)
		{
			base.Activate();

			Debug.Log("Tone sound is playing");
			Debug.Log("Button order from left: 1, 3, 5, 2, 6");

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
