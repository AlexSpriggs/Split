using UnityEngine;
using System.Collections;

public class PillarScript : MonoBehaviour {

    //heights and color pillar correspondance is here.
    //the order is yellow, black, red, blue, green
    public GameObject Tower;
    public float[] MaxHeights = new float[5];
    private float[] maxHeights = new float[5];
    private enum distances { YELLOW = 0, BLACK, RED, BLUE, GREEN };
    distances range = distances.YELLOW;

    public float[] GetHeights()
    {
        return getHeights();
    }
    private float[] getHeights()
    {
        for (int i = 0; i < MaxHeights.Length; i++)
        {
            maxHeights[i] = MaxHeights[i];
        }
        return maxHeights;
    }

    public float SetHeight(Color keyColor, float[] heightPerColor)
    {
        return setHeight(keyColor, heightPerColor);
    }

    //Yellow is first followed by black.
    private float setHeight(Color keyColor, float[] heightPerColor)
    {
        range = checkKeyColor(keyColor);
        if (keyColor == Color.yellow)
        {
            return heightPerColor[(int)range];
        }
        else if (keyColor == Color.black)
        {
            //starting position
            return heightPerColor[(int)range];
        }
        else if (keyColor == Color.red)
        {
            return heightPerColor[(int)range];
        }
        else if (keyColor == Color.blue)
        {
            return heightPerColor[(int)range];
        }
        else if (keyColor == Color.green)
        {
            return heightPerColor[(int)range];
        }

        //should never hit
        Debug.Log("values larger than setable in setHeights are being sent.");
        return 100f;
    }

    private distances checkKeyColor(Color keyColor)
    {
        if (keyColor == Color.yellow)
        {
            return distances.YELLOW;
        }
        else if (keyColor == Color.black)
        {
            //starting position
            return distances.BLACK;
        }
        else if (keyColor == Color.red)
        {
            return distances.RED;
        }
        else if (keyColor == Color.blue)
        {
            return distances.BLUE;
        }
        else if (keyColor == Color.green)
        {
            return distances.GREEN;
        }
        else
            Debug.Log("An unknown keyColor has been passed to " + this
                + "checkKeyColor");
            return distances.YELLOW;
    }
}
