using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Telegram<T> : EventArgs
{
	public List<T> TargetList { get; private set; }
	public T Target { get; private set; }

	public object Source { get; private set; }

	public Telegram(T target)
	{
		Target = target;
	}

	public Telegram(T target, object source)
	{
		Target = target;
		Source = source;
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

public class PlatformTelegram : Telegram<Platform>
{
	public Vector3 MoveDistance;

	public PlatformTelegram(Platform target, Vector3 moveToPosition)
		: base(target) 
	{
		MoveDistance = moveToPosition;
	}

	public PlatformTelegram(Platform target, object source)
		: base(target, source)
	{

	}

	public PlatformTelegram(List<Platform> targets, Vector3 moveToPosition)
		: base(targets) 
	{
		MoveDistance = moveToPosition;
	}
}
