using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Walls : MonoBehaviour 
{
    private List<DimensionWall> puzzleWalls = new List<DimensionWall>();
    [HideInInspector]
    public List<DimensionWall> PuzzleWalls { get { return puzzleWalls; } }
	void Start () 
    {
        puzzleWalls.AddRange(gameObject.GetComponentsInChildren<DimensionWall>());
        puzzleWalls.RemoveAll(g => g.name.Contains("_Double"));
        
        Debug.Log(puzzleWalls.ToString() + " count: " + puzzleWalls.Count);
	}
}
