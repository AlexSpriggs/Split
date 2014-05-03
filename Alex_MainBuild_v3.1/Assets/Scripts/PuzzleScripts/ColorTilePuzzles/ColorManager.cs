using UnityEngine;
using System.Collections;

public class ColorManager : MonoBehaviour {

    //READ IF DEBUGGING COLORS PillarScript sets height by color
    private PrevColorClass[] prevColorClass;
    public int PrevColorClassCount;
    
	// Use this for initialization
	void Start () 
    {
        prevColorClass = new PrevColorClass[PrevColorClassCount];
        for (int i = 0; i < prevColorClass.Length; i++)
		{
			 prevColorClass[i] = ScriptableObject.CreateInstance<PrevColorClass>();
             prevColorClass[i].Initialize(4);
		}
	}
	
    public bool CheckForColorChange(GameObject[] tilesToCheck, TileSolution.PillarLocation pillarLocation, int[] tilePillars)
    {
        //TODO see if tileTocheck.Length can replace 4
        Color[] tilesColorToCheck = new Color[4];
        tilesColorToCheck = assignCheckedColors(tilesToCheck, tilePillars);

        //TODO Remove and replace with below if works.

        if (tilePillars.Length == 0)
        {
            prevColorClass[(int)pillarLocation].InitialColorToCheck(tilesColorToCheck);
        }
        else
            prevColorClass[(int)pillarLocation].InitialColorToCheck(tilesColorToCheck);

        for (int i = 0; i < tilesColorToCheck.Length; i++)
        {
            //Add pillarLocation back if i in prevColorClass doesn't work.
            if (prevColorClass[(int)pillarLocation].PrevColorToCheck[i] == tilesColorToCheck[i])
            {
                if (i == (tilesColorToCheck.Length - 1))
                {
                    return true;
                }
                else if (tilePillars.Length == 1 && i == 0)
                {
                    return true;
                }
            }
            else
            {
                prevColorClass[(int)pillarLocation].SetPrevColor(tilesColorToCheck);

                return false;
            }

        }
        return false;
    }

    private Color[] assignCheckedColors(GameObject[] tilesToCheck, int[] tilePillars)
    {
        return selectFromTiles(tilesToCheck, tilePillars);
    }

    private Color[] selectFromTiles(GameObject[] tilesToCheck, int[] tilePillars)
    {
        //TODO Make dynamic
        Color[] tempColors = new Color[tilePillars.Length];

        for (int i = 0; i < tempColors.Length; i++)
        {
            if(i < tilesToCheck.Length)
                tempColors[i] = tilesToCheck[tilePillars[i]].renderer.material.color;
            //else
            //    tempColors[i] = tilesToCheck[tilePillars[0]].renderer.material.color;
        }

        return tempColors;
    }
}
