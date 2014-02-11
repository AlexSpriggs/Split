using UnityEngine;
using System.Collections;

public class GoldenSphereUI : MonoBehaviour {

	public GameObject SphereOne, SphereTwo, SphereThree, SphereFour, SphereFive;

	public GameObject UiSphereOne, UiSphereTwo, UiSphereThree, UiSphereFour, UiSphereFive;

	// Use this for initialization
	void Start () {

		UiSphereOne.GetComponent<MeshRenderer>().enabled = false;
		UiSphereTwo.GetComponent<MeshRenderer>().enabled = false;
		UiSphereThree.GetComponent<MeshRenderer>().enabled = false;
		UiSphereFour.GetComponent<MeshRenderer>().enabled = false;
		UiSphereFive.GetComponent<MeshRenderer>().enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {

		if(SphereOne == null)
			UiSphereOne.GetComponent<MeshRenderer>().enabled = true;
		if(SphereTwo == null)
			UiSphereTwo.GetComponent<MeshRenderer>().enabled = true;
		if(SphereThree == null)
			UiSphereThree.GetComponent<MeshRenderer>().enabled = true;
		if(SphereFour == null)
			UiSphereFour.GetComponent<MeshRenderer>().enabled = true;
		if(SphereFive == null)
			UiSphereFive.GetComponent<MeshRenderer>().enabled = true;
	
	}
}
