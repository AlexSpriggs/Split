using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallButton : ButtonBase 
{
    public List<GameObject> MyWalls;

    private bool lockSwitches = false;

    public override void HandleMessage(Telegram telegram)
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
        for (int i = 0; i < 60; ++i)
        {
            transform.Translate(Vector3.down * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (!lockSwitches)
        {
            if (col.gameObject.tag == "Player")
            {
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
}
