using UnityEngine;
using System.Collections;

public class GatePillar : PuzzleObject {

	public bool moveDown = false;

	public float moveSpeed;

	private Vector3 down = new Vector3(0, 1, 0);

	private  bool solved;
	public  bool Solved
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
			transform.position -= down * moveSpeed * Time.deltaTime;

			StartCoroutine("StartCountdown");
		}
	}

	IEnumerator StartCountdown()
	{
		solved = true;

		yield return new WaitForSeconds(5);

		SaveState();
		
		destroyGate();
	}

	private void destroyGate()
	{
		Destroy(gameObject);
	}
}
