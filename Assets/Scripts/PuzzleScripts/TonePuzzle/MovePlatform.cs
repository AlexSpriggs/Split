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
		this.moveDistance = new Vector3(moveDistance.x, moveDistance.y,
			moveDistance.z * timesMoved);
	}

	private float startTime;
	public void SetStartTime() 
	{
		startTime = Time.time;
	}

	private float speed = 100f;

	private int timesMoved = 1;

	private Platform platform;

	private bool moving;
	public bool Moving { get { return moving; } }

	public MovePlatform(Platform platform)
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
		moving = false;
		
		while ((startPosition - platform.gameObject.transform.position).sqrMagnitude < moveDistance.sqrMagnitude)
		{
			float mag = (startPosition - platform.gameObject.transform.position).sqrMagnitude;
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / (startPosition.magnitude + moveDistance.magnitude);
			platform.gameObject.transform.position = Vector3.Lerp(startPosition, startPosition + moveDistance, fracJourney);

			if (Mathf.Abs((startPosition - platform.gameObject.transform.position).sqrMagnitude - moveDistance.sqrMagnitude) < .01f)
				break;
			yield return new WaitForFixedUpdate();
		}

		moving = true;
		//if (Solution.Instance.Solved())
		//	platform.SaveState();
	}

	private IEnumerator MoveTo()
	{
		moving = false;
		while (platform.gameObject.transform.position != moveDistance)
		{
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / moveDistance.magnitude;
			platform.gameObject.transform.position = Vector3.Lerp(startPosition, moveDistance, fracJourney);
			yield return new WaitForFixedUpdate();
		}

		Debug.Log("Platform Position: " +
			platform.gameObject.transform.position);

		moving = true;
		//if (Solution.Instance.Solved())
		//	platform.SaveState();
	}

	public void ResetTimesMoved()
	{
		timesMoved = 1;
	}
}
