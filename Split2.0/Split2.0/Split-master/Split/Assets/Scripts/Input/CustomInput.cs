using UnityEngine;
using System.Collections;

public static class CustomInput 
{
	public static bool GetButtonDown(string buttonName)
	{
		if (Input.GetButtonDown(buttonName))
			return true;
		else
			return false;
	}
}
