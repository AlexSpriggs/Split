using UnityEngine;
using System.Collections;

public class ResetPosition 
{
	private GameObject gameObject;

	private Vector3 initialPosition;

	private MovePlatform movePlatform;

	private Platform platform;
	public ResetPosition(Platform platform, Vector3 initialPosition)
	{
		this.platform = platform;
		this.gameObject = platform.gameObject;
		this.initialPosition = initialPosition;

		movePlatform = platform.GetMovePlatform;
	}

	public override bool Equals(object obj)
	{
		GameObject g = (GameObject)obj;

		if (g == gameObject)
		{
			Debug.Log("g Name: " + g.name + " Instance ID: " + g.GetInstanceID());
			Debug.Log("gameObject Name: " + gameObject.name + " Instance ID: " + gameObject.GetInstanceID());
			return true;
		}
		else
			return false;
	}

	public bool Equals(GameObject gameObject)
	{
		if (this.gameObject == gameObject)
		{
			return true;
		}
		else
			return false;
	}

	public void ResetToInitialPosition()
	{
		movePlatform.ResetTimesMoved();

		movePlatform.StartPosition = gameObject.transform.position;
		movePlatform.SetStartTime();

		movePlatform.SetMoveDistance(initialPosition);
		movePlatform.Run(MoveType.MOVETO);
	}
}
