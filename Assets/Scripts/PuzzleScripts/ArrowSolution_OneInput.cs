using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArrowSolution_OneInput : ArrowSolution {

    public List<GameObject> Pillars = new List<GameObject>();

	// Update is called once per frame
	protected override void Update () 
    {
        if (this.correct)
        {
            foreach (GameObject go in Pillars)
            {
                if (go != null)
                {
                    go.GetComponent<GatePillar>().moveDown = true;
                }
            } 
        }
	}

    public override void CheckSolution(ArrowDirection arrowDirection)
    {
        if (arrowDirection == ArrowDirection.UP)
        {
            this.correct = true;
        }
    }

}
