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

			movePlatform.SetMoveDistance(platforms.MoveDistance);
			movePlatform.Run(MoveType.MOVE);
		}
	}

	public void SubScribe()
	{
		MessageDispatcher.Instance.SendMessagePlatform += new MessageDispatcher.SendMessageHandler<Telegram<Platforms>>(HandleMessage);
	}

	public void UnSubScribe()
	{
		MessageDispatcher.Instance.SendMessagePlatform -= new MessageDispatcher.SendMessageHandler<Telegram<Platforms>>(HandleMessage);
	}
}
