using UnityEngine;
using System.Collections;

public class GatePillar : PuzzleObject, IReceiver<GatePillar> 
{
	[HideInInspector]
	public bool moveDown = false;

	public float moveSpeed;

	private Vector3 down = new Vector3(0, 1, 0);

	private  bool solved;
	public  bool Solved
	{
		get { return solved; }
	}

	private int messagesSent = 0;
	private const int messagesNeeded = 2;

	protected override void Start()
	{
		base.Start();

		SubScribe();

		if (CareTaker.Instance.Exists(this))
			destroyGate();
	}

	void Update () {

		if(moveDown)
		{
			transform.position -= down * moveSpeed * Time.deltaTime;

			StartCoroutine("StartCountdown");
		}
	}

	
	IEnumerator StartCountdown()
	{
		solved = true;

		yield return new WaitForSeconds(5);

		SaveState();
		
		destroyGate();
	}

	private void destroyGate()
	{
		Destroy(gameObject);
	}

	public void SubScribe()
	{
		MessageDispatcher.Instance.SendMessagePillar +=
			new MessageDispatcher.SendMessageHandler<Telegram<GatePillar>>(HandleMessage);
	}

	public void UnSubScribe()
	{
		MessageDispatcher.Instance.SendMessagePillar -=
			new MessageDispatcher.SendMessageHandler<Telegram<GatePillar>>(HandleMessage);
	}

	// Used for buttons for opening goal object gate.
	public void HandleMessage(Telegram<GatePillar> telegram)
	{
		if (telegram.Target == this)
		{
			messagesSent++;

			if (messagesSent == messagesNeeded)
				moveDown = true;
		}
	}
}
