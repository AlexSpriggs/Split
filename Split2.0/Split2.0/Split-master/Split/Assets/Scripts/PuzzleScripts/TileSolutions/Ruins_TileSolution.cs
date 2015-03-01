using UnityEngine;
using System.Collections;

public class Ruins_TileSolution : TileSolution 
{
	protected override void Start () 
	{
		setUpPillarManager();

		assignTilePillars();

		for (int i = 0; i < getPillarLocation.Length; i++)
		{
			createPrevColorClass(i);
			assignPillarLocationEnum(i);
		}
	}

	protected override void assignTilePillars()
	{
		tilesPillarOne = new int[3] { 0, 3, 6 };
		tilesPillarTwo = new int[3] { 1, 4, 7 };
		tilesPillarThree = new int[3] { 2, 5, 8 };
		tilesPillarFour = new int[3] { 5, 4, 3 };
		base.assignTilePillars();
	}
	
	// Update is called once per frame
	void Update () 
	{
		pillarManager.CheckPillar(tiles[0], tiles[3], tiles[6]);
		pillarManager.RaisePillars(getPillarLocation[0], tilePillars);

		pillarManager.CheckPillar(tiles[1], tiles[4], tiles[7]);
		pillarManager.RaisePillars(getPillarLocation[1], tilePillars);

		pillarManager.CheckPillar(tiles[2], tiles[5], tiles[8]);
		pillarManager.RaisePillars(getPillarLocation[2], tilePillars);

		pillarManager.CheckPillar(tiles[5], tiles[4], tiles[3]);
		pillarManager.RaisePillars(getPillarLocation[3], tilePillars);
	}

	protected override void checkTileColor()
	{
		
	}
}
