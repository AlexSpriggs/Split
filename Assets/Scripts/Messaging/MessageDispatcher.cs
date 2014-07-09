using UnityEngine;
using System.Collections;

public class MessageDispatcher 
{
    public delegate void SendMessageHandler<T>(T telegram);
	public event SendMessageHandler<Telegram<Platform>> SendMessagePlatform;
    public event SendMessageHandler<Telegram<ButtonBase>> SendMessageButton;
	public event SendMessageHandler<Telegram<Cubes>> SendMessageCubes;

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
}
