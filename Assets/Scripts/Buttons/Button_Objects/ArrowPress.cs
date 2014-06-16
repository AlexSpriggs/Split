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

        if (!lockSwitches && !Activated)
        {
			base.Activate();

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
		gameObject.renderer.material.color = startColor;
	}

    protected override void callCoroutine()
    {
        throw new System.NotImplementedException();
    }

	public override void HandleMessage(Telegram<ButtonBase> telegram)
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
