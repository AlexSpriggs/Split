using UnityEngine;
using System.Collections;

public class RiftBehavior : MonoBehaviour {

	RiftManagerScript RMS;

	// Use this for initialization
	void Start () {
		RMS = GameObject.FindGameObjectWithTag("RiftManager").GetComponent<RiftManagerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if(RMS.currentRift == RiftManagerScript.rifts.knew)
			this.gameObject.renderer.material.color = Color.blue;
		if(RMS.currentRift == RiftManagerScript.rifts.old)
			this.gameObject.renderer.material.color = Color.red;
	
	}
}
