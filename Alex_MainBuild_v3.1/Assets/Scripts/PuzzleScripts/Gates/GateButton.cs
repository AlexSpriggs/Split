using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GateButton : MonoBehaviour {


	public List<GameObject> GatePillars = new List<GameObject>();

	bool doOnce = true;


	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			if(doOnce)
			{
				doOnce = false;

				audio.Play ();

				foreach(GameObject go in GatePillars)
				{
					go.GetComponent<GatePillar>().moveDown = true;
				}
			}
		}
	}

}
