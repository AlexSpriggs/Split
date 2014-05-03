using UnityEngine;
using System.Collections;

public class ButtonMover : MonoBehaviour {

    public GameObject MyButton;

    // Use this for initialization
    void Start()
    {

        transform.position = MyButton.transform.position;

    }
    void Update()
    {

        transform.position = MyButton.transform.position;

    }
}
