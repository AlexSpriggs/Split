using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum PillarLocation { FIRST = 0, SECOND, THIRD, FOURTH };
public class TileSolution : MonoBehaviour, ISubject {

	// Use this for initialization
    public GameObject[] tiles;
    public GameObject[] Tiles { get { return tiles; } }

    public GameObject[] Pillars = new GameObject[4];

    protected int[] tilesPillarOne = new int[4] { 0, 1, 3, 4 };
    protected int[] tilesPillarTwo = new int[4] { 1, 2, 5, 4 };
    protected int[] tilesPillarThree = new int[4] { 3, 6, 7, 4 };
    protected int[] tilesPillarFour = new int[4] { 5, 7, 8, 4 };

    protected int[][] tilePillars = new int[4][];

    [HideInInspector]
    public PillarScript[] PillarsClass = new PillarScript[4];

    public GameObject PillarManager_GO;
    protected PillarManager pillarManager;
    
    public enum PillarLocation { FIRST = 0, SECOND, THIRD, FOURTH };
    PillarLocation[] pillarLocation = new PillarLocation[4];
    //Change implementation of getPillarLocation if we need more than four pillars
    protected PillarLocation[] getPillarLocation { get { return pillarLocation; } }

    protected PrevColorClass[] prevColorClass = new PrevColorClass[4];

    void Awake()
    {
        observers = new List<IObserver>();
    }

	protected virtual void Start () 
    {
        //TODO figure out how to dynamically add tiles in predetermined order.
        setUpPillarManager();

        assignTilePillars();

        for (int i = 0; i < pillarLocation.Length; i++)
        {
            createPrevColorClass(i);
            assignPillarLocationEnum(i);
        }
	}

    protected virtual void assignPillarLocationEnum(int i)
    {
        pillarLocation[i] = (PillarLocation)i;
    }

    //TODO check if needed.
    protected virtual void createPrevColorClass(int i)
    {
        prevColorClass[i] = ScriptableObject.CreateInstance<PrevColorClass>();
        prevColorClass[i].Initialize(4);
    }
    protected virtual void assignTilePillars()
    {
        tilePillars[0] = tilesPillarOne;
        tilePillars[1] = tilesPillarTwo;
        tilePillars[2] = tilesPillarThree;
        tilePillars[3] = tilesPillarFour;
    }

    protected virtual void setUpPillarManager()
    {
        pillarManager = PillarManager_GO.GetComponent<PillarManager>();
    }
	// Update is called once per frame
	void Update () 
    {
        checkTileColor();

        pillarSolution();
	}

    protected virtual void pillarSolution()
    {
		for (int i = 0; i < tiles.Length; i++) 
		{
			if (tiles[i].GetComponent<Tile>().TilePressed) 
			{
				this.pillarManager.SetStopFirstMovement();
			}
		}


        for (int i = 0; i < pillarLocation.Length; i++)
        {
            pillarManager.RaisePillars(pillarLocation[i], tilePillars);
        }
    }
   
    protected virtual void checkTileColor()
    {
        //Order of Pillar checks first, second, third, fourth
        pillarManager.CheckPillar(tiles[0], tiles[1], tiles[3], tiles[4]);
        pillarManager.CheckPillar(tiles[1], tiles[2], tiles[5], tiles[4]);
        pillarManager.CheckPillar(tiles[3], tiles[6], tiles[7], tiles[4]);
        pillarManager.CheckPillar(tiles[5], tiles[7], tiles[8], tiles[4]);
    }

    #region ISubject Code
    List<IObserver> observers;

    //TODO Test this and play with script order
    public void Attach(IObserver o)
    {
        this.observers.Add(o);
    }

    public void Detach(IObserver o)
    {
        this.observers.Remove(o);
    }

    public void Notify()
    {
        foreach (IObserver o in observers)
        {
            o.ObserverUpdate(this, Tiles);
        }
    }
    #endregion
}
