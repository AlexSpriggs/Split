using UnityEngine;
using System.Collections;

public interface IActivate 
{
	void HighLight();
	void DeSelect();
	void Activate();
	IEnumerator FlashColors();
}
