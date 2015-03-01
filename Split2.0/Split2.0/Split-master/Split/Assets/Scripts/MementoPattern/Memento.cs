using UnityEngine;
using System.Collections;

public class Memento<t>
{
	private t state;
	
	public t GetState()
	{
		return state;
	}

	public void SetState(t state)
	{
		this.state = state;
	}
}
