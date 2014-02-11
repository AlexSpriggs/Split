using UnityEngine;
using System.Collections;
using System.Linq;

public class ArrowSolution_FinalPuzzle : ArrowSolution {
	
	// Update is called once per frame
	protected override void Update () 
    {
        if (correct)
        {
            Debug.Log("Need to add what happens");
        }
	}

    public override void CheckSolution(ArrowDirection arrowDirection)
    {
        orderPressed.Add(arrowDirection);

        //Oreder is left, down, up, up, right, down
        if (orderPressed != null)
        {
            switch (count)
            {
                case 0:
                    checkSolution(ArrowDirection.LEFT);
                    break;
                case 1:
                    checkSolution(ArrowDirection.DOWN);
                    break;
                case 2:
                    checkSolution(ArrowDirection.UP);
                    break;
                case 3:
                    checkSolution(ArrowDirection.UP);
                    break;
                case 4:
                    checkSolution(ArrowDirection.RIGHT);
                    break;
                case 5:
                    checkSolution(ArrowDirection.DOWN);
                    break;
            }
        }
            
    }

    private void checkSolution(ArrowDirection arrowDirection)
    {
        if (count == 5)
            correct = true;
        else if (orderPressed.Last<ArrowDirection>() == arrowDirection)
            this.count++;
        else
        {
            orderPressed.Clear();
            this.count = 0;
        }
            
    }
}
