using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float speed;
	public float jumpD;
	KeyManagerScript KMS;

	// Use this for initialization
	void Start () {
		KMS = GameObject.FindGameObjectWithTag ("KeyManager").GetComponent<KeyManagerScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KMS.forward)) {
			rigidbody.AddForce(Vector3.forward * speed);
		}
		if (Input.GetKey (KMS.back)) {
			rigidbody.AddForce(-Vector3.forward * speed);
		}
		if (Input.GetKeyDown(KMS.jump)){
			rigidbody.AddForce(Vector3.up * jumpD);
		}
		if (Input.GetKey (KMS.right)) {
			rigidbody.AddForce(Vector3.right * speed);
		}
		if (Input.GetKey (KMS.left)) {
			rigidbody.AddForce(-Vector3.right * speed);
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "KillBox"){
			this.gameObject.transform.position = new Vector3 (0, 1, 0);
		}
	}
}
