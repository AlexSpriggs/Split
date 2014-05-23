using UnityEngine;
using System.Collections;

public class MessageDispatcher 
{
    public delegate void SendMessageHandler(Telegram telegram);
    public event SendMessageHandler SendMessage;

    private MessageDispatcher() { }

    private static MessageDispatcher instance;
    public static MessageDispatcher Instance
    {
        get { return instance ?? (instance = new MessageDispatcher()); }
    }

    public void DispatchMessage(Telegram telegram)
    {
        if (SendMessage != null)
            SendMessage(telegram);
    }
}
