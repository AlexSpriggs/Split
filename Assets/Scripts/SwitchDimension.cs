using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//TODO Make this a manager
public class SwitchDimension : PuzzleObject
{
    private List<WallButton> wallButtons = new List<WallButton>();

    private ArrowButtonContainer arrowButtonContainer;

    private Walls walls;
    private World lastWall;

    private ButtonTelegram wallButtonsTelegram;
    private ButtonTelegram arrowButtonContainerTelegram;

    protected override void Start()
    {
		base.Start();

        wallButtons.AddRange(gameObject.GetComponentsInChildren<WallButton>());

        arrowButtonContainer = gameObject.GetComponentInChildren<ArrowButtonContainer>();

        walls = gameObject.GetComponentInChildren<Walls>();
        
        wallButtonsTelegram = new ButtonTelegram(wallButtons.Cast<ButtonBase>().ToList());
        arrowButtonContainerTelegram = new ButtonTelegram(arrowButtonContainer);
    }

	void Update () 
    {
        if ((allOnSameLayer() && !locked))
        {
            locked = true;

			saveState();

			saveWallsState();

            MessageDispatcher.Instance.DispatchMessage(wallButtonsTelegram);
            MessageDispatcher.Instance.DispatchMessage(arrowButtonContainerTelegram);
        }
	}

	private void saveWallsState()
	{
		foreach (DimensionWall dw in walls.PuzzleWalls)
		{
			dw.SaveState();
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
