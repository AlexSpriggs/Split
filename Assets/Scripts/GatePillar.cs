using UnityEngine;
using System.Collections;

public class GatePillar : MonoBehaviour {

	public bool moveDown = false;

	public float moveSpeed;

	void Start()
	{

	}

	// Update is called once per frame
	void Update () {

		if(moveDown)
		{
			transform.position -= new Vector3(0, 1, 0) * moveSpeed * Time.deltaTime;

			StartCoroutine("StartCountdown");
		}

	
	}

	IEnumerator StartCountdown()
	{
		yield return new WaitForSeconds(5);

		Destroy(gameObject);
	}
}
