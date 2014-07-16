using UnityEngine;
using System.Collections;

//TODO Once all puzzles are made figure out how to remove StopFirstMovement
//TODO correct changes to values of OneTilePuzzle and ninetile puzzle
public class PillarManager : MonoBehaviour, IObserver {

    public GameObject[] Pillars = new GameObject[4];
    protected PillarScript[] pillarsScript = new PillarScript[4];
    protected float[] heights = new float[4];

    public float Speed;

    private bool moving = false;
    public bool Moving { set { moving = value; } }

    protected GameObject[] tilesToCheck;
    protected ColorManager colorManager;
    public GameObject ColorManager_GO;

    TileSolution tileSolution;

    protected PillarLocation pillarLocation;

    //For all classes that inherit
    protected bool StopFirstMovement = true;

    //Have multiple observers and one subject
    void Awake()
    {
        tileSolution = GameObject.Find("Tiles").GetComponent<TileSolution>(); 
        tileSolution.Attach(this);
		tileSolution.Notify();
		//TODO add in detach after object has attached.
    }
	// Use this for initialization
	void Start () 
    {
        pillarLocation = PillarLocation.FIRST;

        this.colorManager = ColorManager_GO.GetComponent<ColorManager>();

        for (int i = 0; i < pillarsScript.Length; i++)
        {
            pillarsScript[i] = Pillars[i].GetComponent<PillarScript>();
            pillarsScript[i].Tower = Pillars[i];
        }
	}

	public void SetStopFirstMovement()
	{
		StopFirstMovement = false;
	}

    public virtual void RaisePillars(TileSolution.PillarLocation pillarLocation, int[] tilePillar)
    {
        raisePillars(pillarLocation, tilePillar);
    }

    public virtual void RaisePillars(TileSolution.PillarLocation pillarLocation, int[][] tilePillars)
    {
        raisePillars(pillarLocation, tilePillars[(int)pillarLocation]);
    }

    //TODO Remove PillarLocaion if you can think of it.
    protected virtual void raisePillars(TileSolution.PillarLocation pillarLocation, int[] tilePillar)
    {
        switch (pillarLocation)
        {
            case TileSolution.PillarLocation.FIRST:
                if (colorManager.CheckForColorChange(tilesToCheck, pillarLocation, tilePillar))
                {
                    raisePillarToHeight(Pillars[0], heights[(int)TileSolution.PillarLocation.FIRST]);
                }
                    
                break;
            case TileSolution.PillarLocation.SECOND:
                if (colorManager.CheckForColorChange(tilesToCheck, pillarLocation, tilePillar))
                    raisePillarToHeight(Pillars[1], heights[(int)TileSolution.PillarLocation.SECOND]);
                break;
            case TileSolution.PillarLocation.THIRD:
                if (colorManager.CheckForColorChange(tilesToCheck, pillarLocation, tilePillar))
                    raisePillarToHeight(Pillars[2], heights[(int)TileSolution.PillarLocation.THIRD]);
                break;
            case TileSolution.PillarLocation.FOURTH:
                if (colorManager.CheckForColorChange(tilesToCheck, pillarLocation, tilePillar))
                    raisePillarToHeight(Pillars[3], heights[(int)TileSolution.PillarLocation.FOURTH]);
                break;
            default:
                break;
        }
    }

    private void raisePillarToHeight(GameObject pillar, float height)
    {
        if (pillar.transform.localPosition.y >= (height - .5f)
           && pillar.transform.localPosition.y <= (height + .5f))
        {
            pillar.transform.Translate(Vector3.zero);
        }
        else if (pillar.transform.localPosition.y >= height)
        {
            if (!audio.isPlaying)
                audio.Play();
            pillar.transform.Translate(Vector3.down * Speed * Time.deltaTime);
        }
        else if (pillar.transform.localPosition.y <= height)
        {
            if (!audio.isPlaying)
                audio.Play();
            pillar.transform.Translate(Vector3.up * Speed * Time.deltaTime);
        }
    }

    public virtual void CheckPillar(GameObject tileOne, Color keyColor)
    {
        //Debug.Log("Hitting the wrong version of CheckPillar with PillarManagerTwo");
        //Color tileOneColor = assignColor(tileOne);

        //if (tileOneColor == keyColor)
        //    effectOfColor(keyColor);
        Color tileOneColor = assignColor(tileOne);

        if (tileOneColor == keyColor)
            effectOfColor(keyColor);
    }

	public virtual void CheckPillar(GameObject tileOne, GameObject tileTwo, 
		GameObject keyTile)
	{
		Color keyColor = assignColor(keyTile);
		Color tileOneColor = assignColor(tileOne);
		Color tileTwoColor = assignColor(tileTwo);

		if (tileOneColor == keyColor && tileTwoColor == keyColor)
			effectOfColor(keyColor);
	}

    public virtual void CheckPillar(GameObject tileOne, GameObject tileTwo,
        GameObject tileThree, GameObject keyTile)
    {
        Color keyColor = assignColor(keyTile);
        Color tileOneColor = assignColor(tileOne);
        Color tileTwoColor = assignColor(tileTwo);
        Color tileThreeColor = assignColor(tileThree);

        if (tileOneColor == keyColor && tileTwoColor == keyColor
            && tileThreeColor == keyColor)
            effectOfColor(keyColor);
    }

    protected Color assignColor(GameObject gameObjectToAssign)
    {
        return gameObjectToAssign.renderer.material.color;
    }

    //Sets height for each pillar
    protected float[][] distances = new float[4][];
    protected virtual void effectOfColor(Color keyColor)
    {
        if ((int)pillarLocation > 0)
        {
            pillarLocation = 0;
        }
        
        for (int i = 0; i < Pillars.Length; i++)
        {
            distances[i] = new float[4];
            distances[i] = pillarsScript[i].GetHeights();
           	heights[(int)pillarLocation] =  pillarsScript[i].SetHeight(keyColor, distances[i]);
			//Debug.Log("Height of Pillars: " + heights[(int)pillarLocation].ToString());
            pillarLocation++;
        }
    }

    public virtual void ObserverUpdate(object sender, object message)
    {
        if (sender is TileSolution)
        {
            if (message is GameObject[])
            {
                tilesToCheck = (GameObject[])message;
            }
        }
    }
}
