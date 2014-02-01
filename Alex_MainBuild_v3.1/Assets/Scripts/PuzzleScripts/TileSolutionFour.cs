using UnityEngine;
using System.Collections;

public class TileSolutionFour : TileSolutionTwo
{

	// Use this for initialization
	protected override void Start () 
    {
        setUpPillarManager();

        assignTilePillars();

        for (int i = 0; i < getPillarLocation.Length; i++)
        {
            this.createPrevColorClass(i);
            assignPillarLocationEnum(i);
        }
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
