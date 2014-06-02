using UnityEngine;
using System.Collections;

public enum ArrowDirection { LEFT, RIGHT, UP, DOWN };

public class ArrowPress : ButtonBase {

    public ArrowDirection ButtonDirection;
    public GameObject Solution;

    protected override void Start()
    {
        lockSwitches = true;

        base.Start();
    }

	public override void Activate()
    {
        Debug.Log("Selected");

        if (!lockSwitches)
        {
            Activated = true;
            StartCoroutine(FlashColors());
            if (!audio.isPlaying)
                audio.Play();

            Solution.SendMessage("CheckSolution", ButtonDirection);
        }
    }

    public void EnableButton()
    {
        lockSwitches = false;
    }

    public override void HighLight()
	{
		gameObject.renderer.material.color = Color.red;
	}

	public override void DeSelect()
	{
		gameObject.renderer.material.color = color;
	}

	public override IEnumerator FlashColors()
	{
		for (int i = 0; i < 15; i++)
		{
			if (gameObject.renderer.material.color == color)
				gameObject.renderer.material.color = Color.red;
			else
				gameObject.renderer.material.color = color;

			yield return new WaitForSeconds(.5f);
			
		}
        Debug.Log("Colors have flashed");

		Activated = false;
		gameObject.renderer.material.color = color;
	}

    protected override void callCoroutine()
    {
        throw new System.NotImplementedException();
    }

    public override void HandleMessage(Telegram telegram)
    {
        if (telegram.TargetList != null)
        {
            if (telegram.TargetList.Contains(this))
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
