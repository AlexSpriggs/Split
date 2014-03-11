using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwitchDimension : MonoBehaviour {

	public List<GameObject> MyWalls;
    public List<GameObject> AllWalls;
    public GameObject PuzzleButtons;
    private static bool puzzleButtonsAreRaising = false;
    private bool lockSwitches = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (allOnLayer8() || allOnLayer9())
        {
            lockSwitches = true;
            StartCoroutine(LowerSwitch());
            if(!puzzleButtonsAreRaising)
                StartCoroutine(RaiseButtons());
        }
	
	}

    IEnumerator LowerSwitch()
    {
       
        for (int i = 0; i < 30; ++i)
        {
            transform.Translate(Vector3.down * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }

    }

    IEnumerator RaiseButtons()
    {
        puzzleButtonsAreRaising = true;
        for (int i = 0; i < 30; ++i)
        {
            //PuzzleButtons.transform.position += new Vector3(PuzzleButtons.transform.position.x,
            //    .5f / 30,
            //    PuzzleButtons.transform.position.z);
            PuzzleButtons.transform.Translate(Vector3.up * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }

    }

    private bool allOnLayer8()
    {
        bool allOnOneSide = true;
        foreach (GameObject g in AllWalls)
        {
            if(g.gameObject.layer == 9)
                allOnOneSide = false;
        }


        return allOnOneSide;

    }

    private bool allOnLayer9()
    {
        bool allOnOneSide = true;
        foreach (GameObject g in AllWalls)
        {
            if (g.gameObject.layer == 8)
                allOnOneSide = false;
        }


        return allOnOneSide;

    }

	void OnTriggerEnter(Collider col)
	{
        if (!lockSwitches)
        {
            if (col.gameObject.tag == "Player")
            {
                if (!audio.isPlaying)
                    audio.Play();
                foreach (GameObject go in MyWalls)
                {
                    go.GetComponent<DimensionWall>().Switch();
                }
            }
        }
	}
}
