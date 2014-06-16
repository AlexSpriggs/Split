using UnityEngine;
using System.Collections;

public class Platforms : MonoBehaviour, IReceiver<Platforms>
{
	private Vector3 startPosition;

	private float startTime;
	private float speed = 100f;

	private int timesMoved = 1;

	private MovePlatform movePlatform;
	public MovePlatform GetMovePlatform { get { return movePlatform; } }
	// Use this for initialization
	void Awake () 
	{
		movePlatform = new MovePlatform(this);
		SubScribe();
	}

	void OnDestroy()
	{
		UnSubScribe();
	}

	public void HandleMessage(Telegram<Platforms> telegram)
	{
		if(telegram.Target == this)
		{
			PlatformTelegram platforms = telegram as PlatformTelegram;

			movePlatform.StartPosition = gameObject.transform.position;
			movePlatform.SetStartTime();
			//startPosition = gameObject.transform.position;
			//startTime = Time.time;

			movePlatform.SetMoveDistance(platforms.MoveDistance);
			movePlatform.Run(MoveType.MOVE);
			//Vector3 moveDistance = new Vector3(platforms.MoveDistance.x * timesMoved, 
			//	platforms.MoveDistance.y, platforms.MoveDistance.z);
			//StartCoroutine(MovePlatform(moveDistance));
			//timesMoved++;
		}
	}

	//public IEnumerator MovePlatform(Vector3 moveDistance)
	//{
	//	Vector3 startPosition = gameObject.transform.position;
	//	while ((startPosition - gameObject.transform.position).sqrMagnitude < moveDistance.sqrMagnitude)
	//	{
	//		float distCovered = (Time.time - startTime) * speed;
	//		float fracJourney = distCovered / (startPosition.magnitude + moveDistance.magnitude);
	//		gameObject.transform.position = Vector3.Lerp(startPosition, startPosition + moveDistance, fracJourney);
	//		yield return new WaitForFixedUpdate();
	//	}
	//}

	public void SubScribe()
	{
		MessageDispatcher.Instance.SendMessagePlatform += new MessageDispatcher.SendMessageHandler<Telegram<Platforms>>(HandleMessage);
	}

	public void UnSubScribe()
	{
		MessageDispatcher.Instance.SendMessagePlatform -= new MessageDispatcher.SendMessageHandler<Telegram<Platforms>>(HandleMessage);
	}
}
