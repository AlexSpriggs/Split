using UnityEngine;
using System.Collections;

public class Player : ScriptableObject 
{
    private GameObject[] keys = new GameObject[4];
    private int iterator = 0;
    
    static Player()
    {
    
    }

    public void AddKey(GameObject key)
    {
        keys[iterator++] = key;
    }
}
