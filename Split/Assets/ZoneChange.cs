using UnityEngine;
using System.Collections;

public class ZoneChange : MonoBehaviour {

	RiftManagerScript RMS;

	public enum rifts{old, knew};
//	public string ZoneInfo;

	public rifts currentRift;

	// Use this for initialization
	void Start () {
		RMS = GameObject.FindGameObjectWithTag("RiftManager").GetComponent<RiftManagerScript>();
//		if(ZoneInfo == "old")
//			currentRift = rifts.old;
//		else if(ZoneInfo == "knew")
//			currentRift = rifts.knew;
	}
	
	// Update is called once per frame
	void Update () {
		//fix, it works but not in the right way

		if(currentRift == rifts.knew){
			if(RMS.currentRift == RiftManagerScript.rifts.knew){
				this.gameObject.renderer.enabled = false;
				this.gameObject.collider.enabled = false;
			}
			else{
				this.gameObject.renderer.enabled = true;
				this.gameObject.collider.enabled = true;
			}
		}

		if(currentRift == rifts.old){
			if(RMS.currentRift == RiftManagerScript.rifts.old){
				this.gameObject.renderer.enabled = false;
				this.gameObject.collider.enabled = false;
			}else{
				this.gameObject.renderer.enabled = true;
				this.gameObject.collider.enabled = true;
			}
		}

//		if(RMS.currentRift == RiftManagerScript.rifts.knew && currentRift == rifts.knew){
//			print("RMS new, CR new");
//			this.gameObject.SetActive(false);
//		}
//		else if (RMS.currentRift == RiftManagerScript.rifts.old && currentRift == rifts.knew){
//			print("RMS old, CR new");
//			this.gameObject.SetActive(true);
//		}
//
//		else if(RMS.currentRift == RiftManagerScript.rifts.old && currentRift == rifts.old){
//			print("RMS old, CR old");
//			this.gameObject.SetActive(false);
//		}
//		else if (RMS.currentRift == RiftManagerScript.rifts.knew && currentRift == rifts.old){
//			print("RMS new, CR old");
//			this.gameObject.SetActive(true);
//		}
	
	}

	void OnTriggerEnter(Collider other){
		if(RMS.currentRift == RiftManagerScript.rifts.knew && currentRift == rifts.old){
			RMS.currentRift = RiftManagerScript.rifts.old;
		}else if(RMS.currentRift == RiftManagerScript.rifts.old && currentRift == rifts.knew){
			RMS.currentRift = RiftManagerScript.rifts.knew;
		}
	}
}
