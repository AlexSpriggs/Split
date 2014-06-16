using UnityEngine;
using System.Collections;

public class ToneMachine : ButtonBase 
{
	protected override void Start()
	{
		highLightColor = Color.blue;

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
