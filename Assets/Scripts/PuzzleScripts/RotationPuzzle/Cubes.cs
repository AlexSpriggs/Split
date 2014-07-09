using UnityEngine;
using System.Collections;

public class Cubes : PuzzleObject, IReceiver<Cubes>
{
	private float speed = 100f;

	protected override void Awake()
	{
		base.Awake();

		SubScribe();
	}

	protected override void Start()
	{
		base.Start();
	}

	public void SubScribe()
	{
		MessageDispatcher.Instance.SendMessageCubes += 
			new MessageDispatcher.SendMessageHandler<Telegram<Cubes>>(HandleMessage);
	}

	public void UnSubScribe()
	{
		MessageDispatcher.Instance.SendMessageCubes -= 
			new MessageDispatcher.SendMessageHandler<Telegram<Cubes>>(HandleMessage);
	}

	public void HandleMessage(Telegram<Cubes> telegram)
	{
		if(telegram.Target == this)
		{
			CubeTelegram cube = telegram as CubeTelegram;
			StartCoroutine(rotate(cube.Rotation));
		}
	}

	private IEnumerator rotate(Quaternion rotation)
	{
		float time = 0f;
		Quaternion start = transform.rotation;
		while (time < 1f)
		{

			transform.rotation =
				Quaternion.Slerp(start, start * rotation, time);
			time += Time.deltaTime;
			yield return new WaitForFixedUpdate();
		}
	}
}
