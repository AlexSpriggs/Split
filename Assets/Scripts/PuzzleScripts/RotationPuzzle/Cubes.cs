using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cubes : PuzzleObject, IReceiver<Cubes>
{
	private float speed = 100f;

	Quaternion currentRot;

	private bool rotation;
	private bool prevRotation;

	public List<Target> TargetObject = new List<Target>();
	protected override void Awake()
	{
		base.Awake();

		SubScribe();
	}

	protected override void Start()
	{
		TargetObject.AddRange(gameObject.GetComponentsInChildren<Target>());
		base.Start();
	}

	void Update()
	{
		if(Rotator.IsRunning == false)
		{
			prevRotation = Rotator.IsRunning;
		}
		if(rotation != prevRotation)
		{
			Debug.Log("should Fire rotation code");
			rotation = prevRotation = Rotator.IsRunning;
			//TODO implement Target Send Message;
		}
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

			currentRot = cube.Rotation;
			CareTakerCubeRotations.Instance.SaveState(this);

			StartCoroutine(Rotator.Rotate(gameObject, cube.Rotation));
			rotation = prevRotation = Rotator.IsRunning;
		}
	}

	public Memento<Quaternion> CreateRotationMemento()
	{
		Memento<Quaternion> m = new Memento<Quaternion>();
		m.SetState(Quaternion.Inverse(currentRot));
		return m;
	}
}
