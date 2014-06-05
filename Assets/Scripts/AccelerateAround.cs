using UnityEngine;
using System.Collections;

public class AccelerateAround : MonoBehaviour {

    public Transform Core;

    public float Acceleration;

    public float MaximumVelocity = 20;

    Quaternion targetRotation;

	// Use this for initialization
	void Start () {

        Acceleration = Random.Range(5, 10);

        StartCoroutine("ChangeAcceleration");
	
	}
	
	// Update is called once per frame
	void Update () {

        targetRotation = Quaternion.LookRotation(Core.transform.position - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5 * Time.deltaTime);

        Vector3 forward = transform.TransformDirection(Vector3.forward);

        rigidbody.velocity += forward * Acceleration * Time.deltaTime;

        if (rigidbody.velocity.x > MaximumVelocity || rigidbody.velocity.y > MaximumVelocity || rigidbody.velocity.z > MaximumVelocity)
        {
            Vector3 newVelocity = rigidbody.velocity.normalized;
            newVelocity *= MaximumVelocity;
            rigidbody.velocity = newVelocity;
        }
	
	}

    IEnumerator ChangeAcceleration()
    {
        yield return new WaitForSeconds(5);

        Acceleration = Random.Range(5, 50);

        StartCoroutine("ChangeAcceleration");
    }
}
