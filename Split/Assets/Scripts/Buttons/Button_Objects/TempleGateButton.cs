using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TempleGateButton : ButtonBase 
{
	private GatePillar gatePillar;
	protected override void Start () 
	{
		gatePillar = gameObject.transform.parent.GetComponentInChildren<GatePillar>();
		base.Start();
	}

	public override void Activate()
	{
		if (!Activated && !locked)
		{
			base.Activate();

			MessageDispatcher.Instance.DispatchMessage(new Telegram<GatePillar>(gatePillar));
			ColorsShouldFlash();

			locked = true;
		}
	}

	public override void HandleMessage(Telegram<ButtonBase> telegram)
	{
		
	}

	protected override void callCoroutine()
	{
		throw new System.NotImplementedException();
	}
}
