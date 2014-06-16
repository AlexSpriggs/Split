using UnityEngine;
using System.Collections;

public abstract class ButtonBase : MonoBehaviour, IActivate, IReceiver<ButtonBase>
{
    protected bool buttonIsRaising = false;
	
	protected Color startColor;
	protected Color highLightColor = Color.red;

	public bool Activated { get; private set; }
    protected bool lockSwitches;
    protected abstract void callCoroutine();

    protected virtual void Start()
    {
		if(gameObject.renderer != null)
			startColor = gameObject.renderer.material.color;

        SubScribe();
    }

    public virtual void HandleMessage(Telegram<ButtonBase> telegram)
	{
		throw new System.NotImplementedException();
	}

    public void SubScribe()
    {
        MessageDispatcher.Instance.SendMessageButton += new MessageDispatcher.SendMessageHandler<Telegram<ButtonBase>>(HandleMessage);
    }

    public void UnSubScribe()
    {
        MessageDispatcher.Instance.SendMessageButton -= new MessageDispatcher.SendMessageHandler<Telegram<ButtonBase>>(HandleMessage);
    }

	public virtual void Activate()
	{
		Activated = true;
	}

	protected void ColorsShouldFlash()
	{
		StartCoroutine(FlashColors());
	}

	public virtual void HighLight()
	{
		gameObject.renderer.material.color = highLightColor;
	}

	public virtual void DeSelect()
	{
		gameObject.renderer.material.color = startColor;
	}

	public virtual IEnumerator FlashColors()
	{
		// TODO add variable so each button type can have different flash timings
		for (int i = 0; i < 15; i++)
		{
			if (gameObject.renderer.material.color == startColor)
				gameObject.renderer.material.color = highLightColor;
			else
				gameObject.renderer.material.color = startColor;

			yield return new WaitForSeconds(.5f);
		}

		DeActivate();
	}

	private void DeActivate()
	{
		Activated = false;
		gameObject.renderer.material.color = startColor;
	}
	protected void OnDestroy()
	{
		UnSubScribe();
	}
}
