using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallButton : ButtonBase
{
    public List<GameObject> MyWalls;

    protected override void Start()
    {
        lockSwitches = false;

        base.Start();
    }


	public override void HandleMessage(Telegram<ButtonBase> telegram)
    {
        if (telegram.TargetList != null)
        {
            if (telegram.TargetList.Contains(this))
            {
                callCoroutine();
            }
        }
    }

    protected override void callCoroutine()
    {
        StartCoroutine(LowerSwitch());
    }

    private IEnumerator LowerSwitch()
    {
        lockSwitches = true;
        for (int i = 0; i < 300; ++i)
        {
            transform.Translate(Vector3.down * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
    }

    public override void Activate()
    {
		Debug.Log("Button has been pressed");
        if (!lockSwitches && !Activated)
        {
			base.Activate();

			StartCoroutine(FlashColors());
            Debug.Log("Switch Pressed");
            if (!audio.isPlaying)
                audio.Play();
            foreach (GameObject go in MyWalls)
            {
                go.GetComponent<DimensionWall>().SwitchWorld();

                go.GetComponent<DimensionWall>().SwitchMaterial();
            }
        }
    }
}
