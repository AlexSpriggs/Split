using UnityEngine;
using System.Collections;

public enum ArrowDirection { LEFT, RIGHT, UP, DOWN };

public class ArrowPress : ButtonBase {

    public ArrowDirection ButtonDirection;
    public GameObject Solution;

	private GatePillar gatePillar;
    protected override void Start()
    {
		base.Start();

		gatePillar = gameObject.transform.parent.parent.parent.GetComponentInChildren<GatePillar>();

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
		if (gatePillar.Solved)
			DisableButton();
	}

    public void EnableButton()
    {
        locked = false;

		saveState();
    }

	public void DisableButton()
	{
		locked = true;

		saveState();
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
