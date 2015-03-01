using UnityEngine;
using System.Collections;

public class RiftManagerScript : MonoBehaviour {

	public enum rifts{old, knew};
	public rifts currentRift;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		print(currentRift);
	
	}
}
