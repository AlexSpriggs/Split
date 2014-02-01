using UnityEngine;
using System.Collections;

public class TileSolutionThree : TileSolution
{
    // Use this for initialization
    protected override void Start()
    {
        setUpPillarManager();

        assignTilePillars();

        for (int i = 0; i < getPillarLocation.Length; i++)
        {
            createPrevColorClass(i);
            assignPillarLocationEnum(i);
        }
    }

    protected override void createPrevColorClass(int i)
    {
        prevColorClass[i] = ScriptableObject.CreateInstance<PrevColorClass>();
        prevColorClass[i].Initialize(4);
    }

    protected override void assignTilePillars()
    {
        //If doesn't work just assign all pillars to tilesPillarOne
        tilesPillarOne = new int[4] { 0, 0, 0, 0 };
        tilesPillarTwo = new int[4] { 1, 1, 1, 1 };
        tilesPillarThree = new int[4] { 2, 2, 2, 2 };
        tilesPillarFour = new int[4] { 3, 3, 3, 3 };

        //use this setup for four tile puzzle where each button acts individually
        tilePillars[0] = tilesPillarOne;
        tilePillars[1] = tilesPillarTwo;
        tilePillars[2] = tilesPillarThree;
        tilePillars[3] = tilesPillarFour;
    }

    // Update is called once per frame
    void Update()
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
            this.pillarManager.RaisePillars(getPillarLocation[i], tilePillars);
        }
    }

    protected override void checkTileColor()
    {
        this.pillarManager.CheckPillar(tiles[0], tiles[1], tiles[2], tiles[3]);
        //Use this if making a 4 tile puzzle that has each tile effect
        //pillars independently.
        //this.pillarManager.CheckPillar(tiles[0], Color.red);
        //this.pillarManager.CheckPillar(tiles[1], Color.red);
        //this.pillarManager.CheckPillar(tiles[2], Color.red);
        //this.pillarManager.CheckPillar(tiles[3], Color.red);
    }
}
