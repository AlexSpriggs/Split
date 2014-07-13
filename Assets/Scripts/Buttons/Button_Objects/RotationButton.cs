﻿using UnityEngine;
using System.Collections;

public class RotationButton : ButtonBase 
{
	private CubeTelegram cubeTelegram;

	public Vector3 Rotation;

	protected override void Start () 
	{
		Cubes cube = gameObject.GetComponentInParent<CubePedastal>().
						Cube.GetComponent<Cubes>();

		cubeTelegram = new CubeTelegram(cube, Rotation);

		base.Start();
	}

	public override void Activate()
	{
		if (!Activated)
		{
			base.Activate();

			MessageDispatcher.Instance.DispatchMessage(cubeTelegram);

			ColorsShouldFlash();
		}
	}

	protected override void callCoroutine()
	{
		throw new System.NotImplementedException();
	}
}
