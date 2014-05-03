using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

    public float MoveSpeed;

    public bool MoveOnX, MoveOnY, MoveOnZ;

    private Vector3 MoveVector;

    // Use this for initialization
    void Start()
    {

        if (MoveOnX)
            MoveVector = new Vector3(1, 0, 0);
        if (MoveOnY)
            MoveVector = new Vector3(0, 1, 0);
        if (MoveOnZ)
            MoveVector = new Vector3(0, 0, 1);
		if(MoveOnX && MoveOnY)
			MoveVector = new Vector3(1, 1, 0);
		if(MoveOnX && MoveOnZ)
			MoveVector = new Vector3(1, 0, 1);
		if(MoveOnY && MoveOnZ)
			MoveVector = new Vector3(0, 1, 1);

    }
	
	// Update is called once per frame
	void Update () {

        transform.position += MoveVector * MoveSpeed * Time.deltaTime;
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "TrafficEnd")
        {
            Destroy(gameObject);
        }
    
    }
}
