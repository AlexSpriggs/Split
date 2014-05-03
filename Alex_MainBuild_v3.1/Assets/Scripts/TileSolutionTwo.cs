using UnityEngine;
using System.Collections;

public class TileSolutionTwo : TileSolution 
{
    //TODO test removing StopFirstMovement
    // change order of heights assigned.
    //The order of heights to colors is yellow, black, red, blue, green
	protected override void Start () 
    {
        //TODO Test to see if right manager are grabbed.
        setUpPillarManager();

        assignTilePillars();

        for (int i = 0; i < getPillarLocation.Length; i++)
        {
            this.createPrevColorClass(i);
            assignPillarLocationEnum(i);
        }
	}

    protected override void createPrevColorClass(int i)
    {
        prevColorClass[i] = ScriptableObject.CreateInstance<PrevColorClass>();
        prevColorClass[i].Initialize(1);
    }
    protected override void assignTilePillars()
    {
        tilesPillarOne = new int[4] { 0, 0, 0, 0 };
    }
	// Update is called once per frame
	void Update () 
    {
        this.checkTileColor();

        this.pillarSolution();
	}

    protected override void pillarSolution()
    {
		for (int i = 0; i < tiles.Length; i++) 
		{
			if (tiles[i].GetComponent<Tile>().TilePressed) 
			{
				this.pillarManager.SetStopFirstMovement();
			}
		}

        for (int i = 0; i < getPillarLocation.Length; i++)
        {
            this.pillarManager.RaisePillars(getPillarLocation[i], tilesPillarOne);
        }
    }

    protected override void checkTileColor()
    {
		this.pillarManager.CheckPillar(tiles[0], tiles[0].renderer.material.color);
    }
}
