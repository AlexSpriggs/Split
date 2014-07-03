using UnityEngine;
using System.Collections;

public abstract class ButtonBase : PuzzleObject, IActivate, IReceiver<ButtonBase>
{
    protected bool buttonIsRaising = false;
	
	protected Color startColor;
	protected Color highLightColor = Color.red;

	public bool Activated { get; private set; }

    protected abstract void callCoroutine();

    protected override void Start()
    {
		if(gameObject.renderer != null)
			startColor = gameObject.renderer.material.color;

		

        SubScribe();

		base.Start();
    }

    public virtual void HandleMessage(Telegram<ButtonBase> telegram)
	{
		//Should never hit here.
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

	public void HighLight()
	{
		gameObject.renderer.material.color = highLightColor;
	}

	public void DeSelect()
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
