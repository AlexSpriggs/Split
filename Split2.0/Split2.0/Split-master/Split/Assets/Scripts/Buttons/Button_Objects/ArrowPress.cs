using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ArrowDirection { LEFT, RIGHT, UP, DOWN };

public class ArrowPress : ButtonBase {

    public ArrowDirection ButtonDirection;
    public GameObject Solution;

	private List<GatePillar> gatePillars = new List<GatePillar>();
    protected override void Start()
    {
		base.Start();

		gatePillars.AddRange
			(
				gameObject.transform.parent.parent.parent.GetComponentsInChildren<GatePillar>()
			);

		if(!CareTaker.Instance.Exists(this))
			locked = true;
    }

	public override void Activate()
    {
        Debug.Log("Selected");

        if (!locked && !Activated)
        {
			base.Activate();

            StartCoroutine(FlashColors());
            if (!audio.isPlaying)
                audio.Play();

            Solution.SendMessage("CheckSolution", ButtonDirection);
        }
    }

	void Update()
	{
		foreach (GatePillar gatePillar in gatePillars)
		{
			if (gatePillar.Solved)
				DisableButton();
		}
	}

    public void EnableButton()
    {
        locked = false;

		SaveState();
    }

	public void DisableButton()
	{
		locked = true;

		SaveState();
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
