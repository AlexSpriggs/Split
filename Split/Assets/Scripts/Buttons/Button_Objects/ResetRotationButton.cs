using UnityEngine;
using System.Collections;

public class ResetRotationButton : ButtonBase 
{
	Cubes cube;
	protected override void Start () 
	{
		cube = gameObject.GetComponentInParent<CubePedastal>().
						Cube.GetComponent<Cubes>();
		base.Start();

		if(!CareTaker.Instance.Exists(this))
			locked = false;
	}

	public override void Activate()
	{
		if(CareTakerCubeRotations.Instance.ContainsKey(cube) && !Activated &&
			!locked)
		{
			StartCoroutine(ReverseRotation());

			base.Activate();

			ColorsShouldFlash();
		}
	}

	private IEnumerator ReverseRotation()
	{
		while (CareTakerCubeRotations.Instance.ContainsKey(cube))
		{
			if(CareTakerCubeRotations.Instance.IsStackPopulated(cube) && 
				!Rotator.IsRunning)
			{
				StartCoroutine
				(
					Rotator.Rotate(cube.gameObject, CareTakerCubeRotations.Instance.RestoreState(cube))
				);
			}

			yield return new WaitForFixedUpdate();
		}
	}

	protected override void callCoroutine()
	{
		
	}
}
