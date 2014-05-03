using UnityEngine;
using System.Collections;

public class ParentTo : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
			other.gameObject.transform.parent = gameObject.transform;
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
			other.gameObject.transform.parent = null;
	}
}
