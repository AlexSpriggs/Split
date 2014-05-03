using UnityEngine;
using System.Collections;

public class ArrowSolution_OneDImensionWalls : ArrowSolution_OneInput {
    
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
        orderPressed.Add(arrowDirection);
        //left, up, right, down
        for (int i = 0; i < orderPressed.Count; i++)
        {
            switch (i)
            {
                case 0:
                    if (orderPressed[i] == ArrowDirection.LEFT)
                    {
						Debug.Log("Left");
                    }
                    else
                        orderPressed.Clear();
                    break;
                case 1:
                    if (orderPressed[i] == ArrowDirection.UP)
                    {
						Debug.Log("Up");
                    }
                    else
                        orderPressed.Clear();
                    break;
                case 2:
                    if (orderPressed[i] == ArrowDirection.RIGHT)
                    {
						Debug.Log("Right");
                    }
                    else
                        orderPressed.Clear();
                    break;
                case 3:
                    if (orderPressed[i] == ArrowDirection.DOWN)
                    {
                        this.correct = true;
                    }
                    else
                        orderPressed.Clear();
                    break;
                default:
                    break;
            }
        }
    }
}
