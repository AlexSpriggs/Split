using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArrowSolution : MonoBehaviour {

    protected List<ArrowDirection> orderPressed = new List<ArrowDirection>();

    protected bool correct = false;
	protected int count = 0;

    public GameObject Bridge;
	
	// Update is called once per frame
	protected virtual void Update () 
    {
        if (correct && count < 1)
        {
			Bridge.GetComponent<MeshRenderer>().enabled = true;
			Bridge.GetComponent<BoxCollider>().enabled = true;
        }
	}

    public virtual void CheckSolution(ArrowDirection arrowDirection)
    {
        orderPressed.Add(arrowDirection);
        Debug.Log("Count of orderPressed = " + orderPressed.Count);
        for (int i = 0; i < orderPressed.Count; i++)
        {
            switch (i)
            {
                case 0:
                    if (orderPressed[i] == ArrowDirection.DOWN)
                    {

                    }
                    else
                        orderPressed.Clear();
                    break;
                case 1:
					if (orderPressed[i] == ArrowDirection.UP)
                    {

                    }
                    else
                        orderPressed.Clear();
                    break;
                case 2:
					if (orderPressed[i] == ArrowDirection.UP)
                    {

                    }
                    else
                        orderPressed.Clear();
                    break;
                case 3:
					if (orderPressed[i] == ArrowDirection.DOWN)
                    {

                    }
                    else
                        orderPressed.Clear();
                    break;
                case 4:
					if (orderPressed[i] == ArrowDirection.DOWN)
                    {

                    }
                    else
                        orderPressed.Clear();
                    break;
                case 5:
					if (orderPressed[i] == ArrowDirection.UP)
                    {
                        correct = true;
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
