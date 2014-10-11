using UnityEngine;
using System.Collections;

public class Tile : ButtonBase 
{
    //TODO if tiles break add Player back in.
	//public GameObject Player;
	
	Color[] color = new Color[5];
	int colorIterator = 0;

	public bool TilePressed = false;

	// Use this for initialization
	protected override void Start () 
	{
		for (int i = 0; i < color.Length; i++) 
		{
			switch (i) 
			{
			case 0:
				color[i] = Color.black;
                audio.Play();
				break;
			case 1:
				color[i] = Color.red;
                audio.Play();
				break;
			case 2:
				color[i] = Color.blue;
                audio.Play();
				break;
			case 3:
				color[i] = Color.green;
                audio.Play();
				break;
			case 4:
				color[i] = Color.yellow;
                audio.Play();
				break;
			default:
				Debug.Log("Color array size is larger than cases.");
				break;
			}
		}
		
		gameObject.renderer.material.color = color[colorIterator];
		
		colorIterator++;

		waitTimeBetweenFlashes = .1f;
		highLightColor = Color.magenta;

		base.Start();
	}

	public override void Activate()
	{
		if (!Activated && !locked)
		{
			base.Activate();

			TilePressed = true;
			if (!audio.isPlaying)
				audio.Play();
			startColor = color[colorIterator];

			ColorsShouldFlash();

			if (colorIterator == 4)
			{
				colorIterator = 0;
			}
			else
				colorIterator++;
		}
	}

	protected override void callCoroutine()
	{
		throw new System.NotImplementedException();
	}
}
