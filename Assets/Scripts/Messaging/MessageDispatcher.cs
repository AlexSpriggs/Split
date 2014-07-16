using UnityEngine;
using System.Collections;

public class MessageDispatcher 
{
    public delegate void SendMessageHandler<T>(T telegram);
	public event SendMessageHandler<Telegram<Platform>> SendMessagePlatform;
    public event SendMessageHandler<Telegram<ButtonBase>> SendMessageButton;
	public event SendMessageHandler<Telegram<Cubes>> SendMessageCubes;
	public event SendMessageHandler<Telegram<Target>> SendMessageTarget;
	public event SendMessageHandler<Telegram<Targets>> SendMessageTargets;
	public event SendMessageHandler<Telegram<GatePillar>> SendMessagePillar;

    private MessageDispatcher() { }

    private static MessageDispatcher instance;
    public static MessageDispatcher Instance
    {
        get { return instance ?? (instance = new MessageDispatcher()); }
    }

    public void DispatchMessage(ButtonTelegram buttonTelegram)
    {
        if (SendMessageButton != null)
            SendMessageButton(buttonTelegram);
    }

	public void DispatchMessage(PlatformTelegram platformTelegram)
	{
		if (SendMessagePlatform != null)
			SendMessagePlatform(platformTelegram);
	}

	public void DispatchMessage(CubeTelegram cubeTelegram)
	{
		if (SendMessageCubes != null)
			SendMessageCubes(cubeTelegram);
	}

	public void DispatchMessage(Telegram<Target> targetTelegram)
	{
		if (SendMessageTarget != null)
			SendMessageTarget(targetTelegram);
	}

	public void DispatchMessage(Telegram<Targets> targetsTelegram)
	{
		if (SendMessageTargets != null)
			SendMessageTargets(targetsTelegram);
	}

	public void DispatchMessage(Telegram<GatePillar> gatePillarTelegram)
	{
		if (SendMessagePillar != null)
			SendMessagePillar(gatePillarTelegram);
	}
}
