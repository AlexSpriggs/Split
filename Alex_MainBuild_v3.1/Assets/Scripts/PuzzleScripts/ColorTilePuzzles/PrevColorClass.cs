using UnityEngine;
using System.Collections;

public class PrevColorClass : ScriptableObject 
{
    Color[] prevColorToCheck;
    public Color[] PrevColorToCheck { get { return prevColorToCheck; } }
    bool prevColorInitialized = false;
	public PrevColorClass()
    {
        
    }

    public void Initialize(int setLength)
    {
        prevColorToCheck = new Color[setLength];
        initializePrevColor(prevColorToCheck);
    }

    private Color[] initializePrevColor(Color[] prevColorToCheck)
    {
        for (int i = 0; i < prevColorToCheck.Length; i++)
        {
            if (!prevColorInitialized)
            {
                prevColorToCheck[i] = Color.white;
                if (i == (prevColorToCheck.Length - 1))
                {
                    prevColorInitialized = true;
                }
            }
        }
        return prevColorToCheck;
    }

    public void SetPrevColor(Color[] tileColorToCheck)
    {
        setPrevColor(tileColorToCheck);
    }

     private void setPrevColor(Color[] tilesColorToCheck)
    {
         //TODO fix index out of range error for OneTile Puzzle
        int checkedColor = 1;
        for (int i = 0; i < tilesColorToCheck.Length; i++)
        {
            if (prevColorToCheck[i] == tilesColorToCheck[i])
                prevColorToCheck[i] = prevColorToCheck[i];
            else if (prevColorToCheck[i] != tilesColorToCheck[i] && 
                checkAllTilesForSameColor(tilesColorToCheck[i], tilesColorToCheck[checkedColor]))
                prevColorToCheck[i] = tilesColorToCheck[i];

            if (checkedColor == (tilesColorToCheck.Length - 1))
            {
                checkedColor = 0;
            }
            else
                checkedColor++;
        }
    }

     private bool checkAllTilesForSameColor(Color tilesColorToCheck, Color checkAgainst)
     {
         if (tilesColorToCheck == checkAgainst)
             return true;
         else
             return false;
     }

    public void InitialColorToCheck(Color[] tilesColorToCheck)
    {
        initialColorToCheck(tilesColorToCheck);
    }

    private void initialColorToCheck(Color[] tilesColorToCheck)
    {
        for (int i = 0; i < tilesColorToCheck.Length; i++)
        {
            if (prevColorToCheck[i] != tilesColorToCheck[i]
                && prevColorToCheck[i] == Color.white)
                prevColorToCheck[i] = tilesColorToCheck[i];
        }
    }  
}
