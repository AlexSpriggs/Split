using UnityEngine;
using System.Collections;

public class Ruins_ArrowSolution : ArrowSolution_OneInput 
{
	public override void CheckSolution(ArrowDirection arrowDirection)
	{
		orderPressed.Add(arrowDirection);
		//right, right, left, up
		for (int i = 0; i < orderPressed.Count; i++)
		{
			switch (i)
			{
				case 0:
					if (orderPressed[i] == ArrowDirection.RIGHT)
					{
						Debug.Log("Right");
					}
					else
						orderPressed.Clear();
					break;
				case 1:
					if (orderPressed[i] == ArrowDirection.RIGHT)
					{
						Debug.Log("Right");
					}
					else
						orderPressed.Clear();
					break;
				case 2:
					if (orderPressed[i] == ArrowDirection.LEFT)
					{
						Debug.Log("Left");
					}
					else
						orderPressed.Clear();
					break;
				case 3:
					if (orderPressed[i] == ArrowDirection.UP)
					{
						Debug.Log("Up");
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
