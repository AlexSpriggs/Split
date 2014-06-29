using UnityEngine;
using System.Collections;

public class GatePillar : PuzzleObject {

	public bool moveDown = false;

	public float moveSpeed;

	private static bool solved;
	public static bool Solved
	{
		get { return solved; }
	}

	protected override void Start()
	{
		base.Start();

		if (CareTaker.Instance.Exists(this))
			destroyGate();
	}

	void Update () {

		if(moveDown)
		{
			transform.position -= new Vector3(0, 1, 0) * moveSpeed * Time.deltaTime;

			StartCoroutine("StartCountdown");
		}
	}

	IEnumerator StartCountdown()
	{
		solved = true;

		yield return new WaitForSeconds(5);

		saveState();
		
		destroyGate();
	}

	private void destroyGate()
	{
		Destroy(gameObject);
	}
}
