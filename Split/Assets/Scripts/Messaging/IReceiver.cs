using UnityEngine;
using System.Collections;
using System;

public interface IReceiver<T>
{
	void SubScribe();
	void UnSubScribe();
	void HandleMessage(Telegram<T> telegram);
}
