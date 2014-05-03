using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SwitchDimension : MonoBehaviour {

	public List<GameObject> MyWalls;
	public List<GameObject> AllWalls;

	public GameObject PuzzleButtons;
    private WallPuzButtons wallPuzButtons;

	public Shader transparent,Specular;

	private bool lockSwitches = false;

	private DimensionWall dw;
    private World lastWall;

	static float baseColor = 255;	
	Color transColor = new Color(30f / baseColor, 255f / baseColor , 0f / baseColor);
	Color solidColor = new Color(188f / baseColor, 0f / baseColor , 255f / baseColor);
	
    void Start()
    {
        wallPuzButtons = PuzzleButtons.GetComponent<WallPuzButtons>();

        lastWall = AllWalls.Last<GameObject>().GetComponent<DimensionWall>().CameraSpace;

        changeButtonColor();
    }
	// Update is called once per frame
	void Update () {

        if (allOnSameLayer())
        {
            lockSwitches = true;
            StartCoroutine(LowerSwitch());
            if (!wallPuzButtons.PuzzleButtonsAreRaising)
                StartCoroutine(RaiseButtons());
        }
	
	}

    IEnumerator RaiseButtons()
    {
        wallPuzButtons.PuzzleButtonsAreRaising = true;
        for (int i = 0; i < 60; ++i)
        {
            PuzzleButtons.transform.Translate(Vector3.up * Time.deltaTime);
            yield return new WaitForFixedUpdate();
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

    private bool allOnSameLayer()
    {
        foreach (GameObject g in AllWalls)
        {
            dw = (DimensionWall)g.GetComponent<DimensionWall>();
            if (dw.CameraSpace != lastWall)
                return false;
        }

        return true;
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
                    go.GetComponentInChildren<DimensionWall>().SwitchWorld();

                    go.GetComponent<DimensionWall>().SwitchMaterial();
                    go.GetComponentInChildren<DimensionWall>().SwitchMaterial();
                }
            }
        }

        changeButtonColor();
	}

    // No longer serves a purpose with current puzzles.
	private void changeButtonColor ()
	{
        
	}
}
