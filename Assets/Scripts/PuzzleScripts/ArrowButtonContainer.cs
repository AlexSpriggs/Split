using UnityEngine;
using System.Collections;

public class ArrowButtonContainer : ButtonBase 
{
    public override void HandleMessage(Telegram telegram)
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
        for (int i = 0; i < 60; ++i)
        {
            transform.Translate(Vector3.up * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
    }
}
