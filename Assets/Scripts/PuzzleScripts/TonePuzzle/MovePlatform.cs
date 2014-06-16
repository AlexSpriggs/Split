using UnityEngine;
using System.Collections;

public enum MoveType {  MOVE, MOVETO };
public class MovePlatform 
{
	private Vector3 startPosition;
	public Vector3 StartPosition { set { startPosition = value; } }

	private Vector3 moveDistance;
	public void SetMoveDistance(Vector3 moveDistance)
	{
		this.moveDistance = new Vector3(moveDistance.x * timesMoved, moveDistance.y,
			moveDistance.z);
	}

	private float startTime;
	public void SetStartTime() 
	{
		startTime = Time.time;
	}

	private float speed = 100f;

	private int timesMoved = 1;

	private Platforms platform;

	public MovePlatform(Platforms platform)
	{
		this.platform = platform;
	}

	public void Run(MoveType moveType)
	{
		switch (moveType)
		{
			case MoveType.MOVE:
				platform.StartCoroutine(Move());
				timesMoved++;
				break;
			case MoveType.MOVETO:
				platform.StartCoroutine(MoveTo());
				break;
			default:
				break;
		}
	}

	private IEnumerator Move()
	{
		while ((startPosition - platform.gameObject.transform.position).sqrMagnitude < moveDistance.sqrMagnitude)
		{
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / (startPosition.magnitude + moveDistance.magnitude);
			platform.gameObject.transform.position = Vector3.Lerp(startPosition, startPosition + moveDistance, fracJourney);
			yield return new WaitForFixedUpdate();
		}
	}

	private IEnumerator MoveTo()
	{
		while (platform.gameObject.transform.position != moveDistance)
		{
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / moveDistance.magnitude;
			platform.gameObject.transform.position = Vector3.Lerp(startPosition, moveDistance, fracJourney);
			yield return new WaitForFixedUpdate();
		}

		Debug.Log("Platform Position: " +
			platform.gameObject.transform.position);
	}

	public void ResetTimesMoved()
	{
		timesMoved = 1;
	}
}
