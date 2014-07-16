using UnityEngine;
using System.Collections;

public class Platform : PuzzleObject, IReceiver<Platform>
{
	private Vector3 startPosition;

	private float startTime;
	private float speed = 100f;

	private int timesMoved = 1;

	private MovePlatform movePlatform;
	public MovePlatform GetMovePlatform { get { return movePlatform; } }
	// Use this for initialization
	protected override void Awake () 
	{
		base.Awake();

		movePlatform = new MovePlatform(this);
		SubScribe();
	}

	protected override void Start()
	{
		if (CareTaker.Instance.Exists(this))
			Solution.Instance.SetPuzzleSolved();

		base.Start();
	}

	void OnDestroy()
	{
		UnSubScribe();
	}

	public void HandleMessage(Telegram<Platform> telegram)
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
		MessageDispatcher.Instance.SendMessagePlatform += new MessageDispatcher.SendMessageHandler<Telegram<Platform>>(HandleMessage);
	}

	public void UnSubScribe()
	{
		MessageDispatcher.Instance.SendMessagePlatform -= new MessageDispatcher.SendMessageHandler<Telegram<Platform>>(HandleMessage);
	}
}
