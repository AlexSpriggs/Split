using UnityEngine;
using System.Collections;

public class ButtonActivator : MonoBehaviour 
{
	private ForwardDirection playerForward;
	// Use this for initialization
	void Start () 
	{
		playerForward = GameObject.FindObjectOfType<ForwardDirection>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerForward.Hit();

		if (playerForward.Button != null)
		{
			if (CustomInput.GetButtonDown("Activate"))
			{
				playerForward.Button.Activate();
			}
		}
	}
}
