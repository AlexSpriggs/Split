using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwitchDimension : MonoBehaviour {

	public List<GameObject> MyWalls;
	public List<GameObject> AllWalls;
	public GameObject PuzzleButtons;
	public Shader transparent,Specular;
	private static bool puzzleButtonsAreRaising = false;
	private bool lockSwitches = false;
	private DimensionWall dw;

	static float baseColor = 255;	
	Color transColor = new Color(30f / baseColor, 255f / baseColor , 0f / baseColor);
	Color solidColor = new Color(188f / baseColor, 0f / baseColor , 255f / baseColor);
	
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
        for (int i = 0; i < 60; ++i)
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
			dw = (DimensionWall)g.GetComponent<DimensionWall>();
			if(dw.SameLayer)
				allOnOneSide = false;
		}
		
		
		return allOnOneSide;
		
	}
	
	private bool allOnLayer9()
	{
		bool allOnOneSide = true;
		foreach (GameObject g in AllWalls)
		{
			dw = (DimensionWall)g.GetComponent<DimensionWall>();
			if(!dw.SameLayer)
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
				Debug.Log("Switch Pressed");
                if (!audio.isPlaying)
                    audio.Play();
                foreach (GameObject go in MyWalls)
                {
                    go.GetComponent<DimensionWall>().Switch();
                }

				changeButtonColor ();

                //TODO move this somewhere else.  It keeps the current puzzle working, but could break something in the future.
                puzzleButtonsAreRaising = false;
            }
        }
	}

	private void changeButtonColor ()
	{
		if (gameObject.renderer.material.color != transColor)
			gameObject.renderer.material.color = transColor;
		else
			if (gameObject.renderer.material.color != solidColor)
				gameObject.renderer.material.color = solidColor;
	}
}
