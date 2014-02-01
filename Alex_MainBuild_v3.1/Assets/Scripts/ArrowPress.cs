using UnityEngine;
using System.Collections;

public enum ArrowDirection { LEFT, RIGHT, UP, DOWN };

public class ArrowPress : MonoBehaviour {

    public ArrowDirection ButtonDirection;
    public GameObject Solution;

	void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
			if(!audio.isPlaying)
				audio.Play();
            Debug.Log("ArrowPress OnTriggerEnter");
            Solution.SendMessage("CheckSolution", ButtonDirection);
        }
    }
}
