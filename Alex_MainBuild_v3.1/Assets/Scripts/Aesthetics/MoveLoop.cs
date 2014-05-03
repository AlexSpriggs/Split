using UnityEngine;
using System.Collections;

public class MoveLoop : MonoBehaviour {

    public GameObject Car;

    public float SpawnCooldown;

	// Use this for initialization
	void Start () {

        StartCoroutine("SpawnCar");
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

    IEnumerator SpawnCar()
    {
        yield return new WaitForSeconds(SpawnCooldown);

        Instantiate(Car, transform.position, transform.rotation);

        StartCoroutine("SpawnCar");
    }
}
