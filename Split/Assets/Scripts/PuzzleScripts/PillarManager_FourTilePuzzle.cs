using UnityEngine;
using System.Collections;

public class PillarManager_FourTilePuzzle : PillarManager 
{
    TileSolutionThree tileSolutionThree;
    //TODO if fails add in StopFirstMovement bool
	// Use this for initialization
	void Start () 
    {
        this.colorManager = ColorManager_GO.GetComponent<ColorManager>();

        for (int i = 0; i < pillarsScript.Length; i++)
        {
            pillarsScript[i] = Pillars[i].GetComponent<PillarScript>();
            pillarsScript[i].Tower = Pillars[i];
        }

        tileSolutionThree = GameObject.Find("TileSolutionThree").GetComponent<TileSolutionThree>();
        tileSolutionThree.Attach(this);
        tileSolutionThree.Notify();
	}

    //Use if needed for desired pillar movement
    public override void RaisePillars(TileSolution.PillarLocation pillarLocation, int[] tilePillar)
    {
        if (!this.StopFirstMovement)
            raisePillars(pillarLocation, tilePillar);
    }

    public override void RaisePillars(TileSolution.PillarLocation pillarLocation, int[][] tilePillars)
    {
       if(!this.StopFirstMovement)
            raisePillars(pillarLocation, tilePillars[(int)pillarLocation]);
    }

    public override void CheckPillar(GameObject tileOne, Color keyColor)
    {
        Color tileOneColor = assignColor(tileOne);

        if (tileOneColor == keyColor)
            effectOfColor(keyColor);
    }

    public override void CheckPillar(GameObject tileOne, GameObject tileTwo, GameObject tileThree, GameObject keyTile)
    {
        Color keyColor = assignColor(keyTile);
        Color tileOneColor = assignColor(tileOne);
        Color tileTwoColor = assignColor(tileTwo);
        Color tileThreeColor = assignColor(tileThree);

        if (tileOneColor == Color.red && tileTwoColor == Color.red &&
            tileThreeColor == Color.red && keyColor == Color.red)
        {
            this.StopFirstMovement = false;
        }

        if (tileOneColor == keyColor && tileTwoColor == keyColor
            && tileThreeColor == keyColor)
            effectOfColor(keyColor);
    }

    protected override void effectOfColor(Color keyColor)
    {
        ///Use in case of pillars moving initially
        
        if ((int)pillarLocation > 0)
        {
            pillarLocation = 0;
        }

        for (int i = 0; i < Pillars.Length; i++)
        {
            distances[i] = new float[4];
            distances[i] = pillarsScript[i].GetHeights();
            heights[(int)pillarLocation] = pillarsScript[i].SetHeight(keyColor, distances[i]);
            //Debug.Log("Height of Pillars: " + heights[(int)pillarLocation].ToString());
            pillarLocation++;
        }
    }

    public override void ObserverUpdate(object sender, object message)
    {
        if (sender is TileSolutionThree)
        {
            if (message is GameObject[])
            {
                this.tilesToCheck = (GameObject[])message;
            }
        }
    }
}
