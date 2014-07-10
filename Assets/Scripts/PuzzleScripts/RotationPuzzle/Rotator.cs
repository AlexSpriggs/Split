using UnityEngine;
using System.Collections;

public static class Rotator 
{
	public static bool IsRunning { get; private set; }
	public static IEnumerator Rotate(GameObject gameObject, Quaternion rotation)
	{
		SetIsRunningTrue();

		float time = 0f;
		Quaternion start = gameObject.transform.rotation;
		
		Quaternion rotateFrom = Quaternion.identity * rotation;
		while (time < 1f)
		{
			gameObject.transform.rotation =
				Quaternion.Slerp(start, rotation * start, time);
			time += Time.deltaTime;
			yield return new WaitForFixedUpdate();
		}

		SetIsRunningFalse();
	}

	private static void SetIsRunningTrue()
	{
		IsRunning = true;
	}

	private static void SetIsRunningFalse()
	{
		IsRunning = false;
	}
}
