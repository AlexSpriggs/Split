using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {

    public GameObject Player;

	// Use this for initialization
	void Start () {

        Player = GameObject.FindGameObjectWithTag("Player");
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.LookAt(Player.transform);
	
	}
}
