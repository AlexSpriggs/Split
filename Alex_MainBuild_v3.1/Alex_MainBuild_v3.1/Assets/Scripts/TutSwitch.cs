using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TutSwitch : MonoBehaviour {

    public List<GameObject> TutObjects;

    public GameObject Platform;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            foreach (GameObject go in TutObjects)
            {
                if (Platform.layer == 8)
                {
                    go.layer = 8;
                }
                else if (Platform.layer == 9)
                    go.layer = 9;
                else if (Platform.layer == 0)
                    go.layer = 0;
            }
        }
    }

}
