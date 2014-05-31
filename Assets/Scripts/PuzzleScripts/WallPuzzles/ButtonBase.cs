using UnityEngine;
using System.Collections;

public abstract class ButtonBase : MonoBehaviour, IActivate
{
    protected bool buttonIsRaising = false;
	protected Color color;

	public bool Activated { get; protected set; }
    protected abstract void callCoroutine();

    protected void Start()
    {
		if(gameObject.renderer != null)
			color = gameObject.renderer.material.color;

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

	public virtual void Activate()
	{
		throw new System.NotImplementedException();
	}

	public virtual void HighLight()
	{
		throw new System.NotImplementedException();
	}


	public virtual void DeSelect()
	{
		throw new System.NotImplementedException();
	}


	public virtual IEnumerator FlashColors()
	{
		throw new System.NotImplementedException();
	}
}
