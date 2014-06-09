using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Telegram<T> : EventArgs
{
	public List<T> TargetList { get; private set; }
	public T Target { get; private set; }

	public Telegram(T target)
	{
		Target = target;
	}

	public Telegram(List<T> targets)
	{
		TargetList = targets;
	}
}

public class ButtonTelegram : Telegram<ButtonBase>
{
	public ButtonTelegram(ButtonBase target)
		: base(target) { }

	public ButtonTelegram(List<ButtonBase> targets)
		: base(targets) { }
}

public class PlatformTelegram : Telegram<Platforms>
{
	public Vector3 MoveDistance;

	public PlatformTelegram(Platforms target, Vector3 moveToPosition)
		: base(target) 
	{
		MoveDistance = moveToPosition;
	}

	public PlatformTelegram(List<Platforms> targets, Vector3 moveToPosition)
		: base(targets) 
	{
		MoveDistance = moveToPosition;
	}
}
