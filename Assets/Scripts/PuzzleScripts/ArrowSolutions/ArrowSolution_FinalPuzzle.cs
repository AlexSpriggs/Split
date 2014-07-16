using UnityEngine;
using System.Collections;
using System.Linq;

public class ArrowSolution_FinalPuzzle : ArrowSolution {
	
	// Update is called once per frame
	protected override void Update () 
    {
        if (correct)
        {
            Application.LoadLevel("End");
            Debug.Log("Need to add what happens");
        }
	}

    public override void CheckSolution(ArrowDirection arrowDirection)
    {
        orderPressed.Add(arrowDirection);

        // Left, Down, Up, Up, Right, Down
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
                    if (orderPressed[i] == ArrowDirection.DOWN)
                    {
                        Debug.Log("Down");
                    }
                    else
                        orderPressed.Clear();
                    break;
                case 2:
                    if (orderPressed[i] == ArrowDirection.UP)
                    {
                        Debug.Log("Up");
                    }
                    else
                        orderPressed.Clear();
                    break;
                case 3:
                    if (orderPressed[i] == ArrowDirection.UP)
                    {
                        Debug.Log("Up");
                    }
                    else
                        orderPressed.Clear();
                    break;
                case 4:
                    if (orderPressed[i] == ArrowDirection.RIGHT)
                    {
                        Debug.Log("Right");
                    }
                    else
                        orderPressed.Clear();
                    break;
                case 5:
                    if (orderPressed[i] == ArrowDirection.DOWN)
                    {
                        correct = true;
                        Debug.Log("Down");
                    }
                    else
                        orderPressed.Clear();
                    break;
            }
        }
    }
}
