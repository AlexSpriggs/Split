using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ArrowButtonContainer : ButtonBase 
{
    private List<ArrowPress> arrowPresses = new List<ArrowPress>();
    protected override void Start()
    {
        arrowPresses = gameObject.GetComponentsInChildren<ArrowPress>().ToList<ArrowPress>();

        Debug.Log("arrowPresses " + arrowPresses.Count);
        base.Start();
    }

	public override void HandleMessage(Telegram<ButtonBase> telegram)
    {
        if (telegram.Target == this)
        {
            callCoroutine();
        }
    }

    protected override void callCoroutine()
    {
        StartCoroutine(RaiseContainer());
    }

    private IEnumerator RaiseContainer()
    {
        for (int i = 0; i < 220; ++i)
        {
            transform.Translate(Vector3.up * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }

        enableButtons();
    }

    private void enableButtons()
    {
        foreach (ArrowPress arrowPress in arrowPresses)
        {
            arrowPress.EnableButton();
        }
    }
}
