using UnityEngine;
using System.Collections;

public abstract class ButtonBase : MonoBehaviour 
{
    protected bool buttonIsRaising = false;

    protected abstract void callCoroutine();

    protected void Start()
    {
        SubScribe();
    }

    public abstract void HandleMessage(Telegram telegram);

    protected void SubScribe()
    {
        MessageDispatcher.Instance.SendMessage += new MessageDispatcher.SendMessageHandler(HandleMessage);
    }

    protected void UnSubSribe()
    {
        MessageDispatcher.Instance.SendMessage -= new MessageDispatcher.SendMessageHandler(HandleMessage);
    }
}
