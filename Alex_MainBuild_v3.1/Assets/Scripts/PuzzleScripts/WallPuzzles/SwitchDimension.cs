using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//TODO Make this a manager
public class SwitchDimension : MonoBehaviour
{
    private List<WallButton> wallButtons = new List<WallButton>();

    private ArrowButtonContainer arrowButtonContainer;

    private bool puzzleIsSolved = false;

    private Walls walls;
    private World lastWall;

    bool Test = true;

    void Start()
    {
        wallButtons.AddRange(gameObject.GetComponentsInChildren<WallButton>());

        arrowButtonContainer = gameObject.GetComponentInChildren<ArrowButtonContainer>();

        walls = gameObject.GetComponentInChildren<Walls>();
        //lastWall = walls.PuzzleWalls.Last<DimensionWall>().GetComponent<DimensionWall>().CameraSpace;
    }

	void Update () 
    {
        if ((allOnSameLayer() && !puzzleIsSolved))
        {
            puzzleIsSolved = true;
            MessageDispatcher.Instance.DispatchMessage(new Telegram(wallButtons.Cast<ButtonBase>().ToList()));
            MessageDispatcher.Instance.DispatchMessage(new Telegram(arrowButtonContainer));
        }
	}

    private bool allOnSameLayer()
    {
        foreach (DimensionWall dw in walls.PuzzleWalls)
        {
            if (dw.CameraSpace != walls.PuzzleWalls.Last<DimensionWall>().GetComponent<DimensionWall>().CameraSpace)
                return false;
        }

        return true;
    }
}
