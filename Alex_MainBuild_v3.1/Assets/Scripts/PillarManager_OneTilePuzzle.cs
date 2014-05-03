using UnityEngine;
using System.Collections;

public class PillarManager_OneTilePuzzle : PillarManager {

    TileSolutionTwo tileSolutionTwo;
    
	// Use this for initialization
	void Start () 
    {
        this.colorManager = ColorManager_GO.GetComponent<ColorManager>();

        for (int i = 0; i < pillarsScript.Length; i++)
        {
            pillarsScript[i] = Pillars[i].GetComponent<PillarScript>();
            pillarsScript[i].Tower = Pillars[i];
        }

        Debug.Log("Pillarmanager_OneTilePUzzle is up.");
        tileSolutionTwo = GameObject.Find("TileSolutionFour").GetComponent<TileSolutionTwo>();
        tileSolutionTwo.Attach(this);
        tileSolutionTwo.Notify();
	}


    public override void RaisePillars(TileSolution.PillarLocation pillarLocation, int[] tilePillar)
    {
        //HACK to stop pillars from moving on load
        if (!StopFirstMovement)
        {
            this.raisePillars(pillarLocation, tilePillar);
        }
        
    }
    //float[] distances = new float[4];
	public override void CheckPillar (GameObject tileOne, Color keyColor)
	{
        Color tileOneColor = assignColor(tileOne);
        if(!StopFirstMovement)
            if (tileOneColor == keyColor)
                effectOfColor(keyColor);  
	}

    protected override void effectOfColor(Color keyColor)
    {
        //HACK for stopping pillars from moving on load.
        this.StopFirstMovement = false;
        if ((int)this.pillarLocation > 0)
        {
            pillarLocation = 0;
        }

        for (int i = 0; i < Pillars.Length; i++)
        {
            distances[i] = pillarsScript[i].GetHeights();
            heights[(int)pillarLocation] = pillarsScript[i].SetHeight(keyColor, distances[i]);

            pillarLocation++;
        }
    }

    public override void ObserverUpdate(object sender, object message)
    {
        if (sender is TileSolutionTwo)
        {
            if (message is GameObject[])
            {
                this.tilesToCheck = (GameObject[])message;
            }
        }
    }
}
