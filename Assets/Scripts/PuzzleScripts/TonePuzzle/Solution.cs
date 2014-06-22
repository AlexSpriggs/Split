using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Solution 
{
	private List<Tones> correctOrder = new List<Tones>();

	private static int currentInput = 0;
	private static int correctInput = 0;
	private int pressLimit;

	private static Solution instance;
	public static Solution Instance
	{
		get { return instance ?? (instance = new Solution()); }
	}

	public void Add(Tones tone)
	{
		correctOrder.Add(tone);
	}

	public void AddRange(List<Tones> tones)
	{
		correctOrder.AddRange(tones);

		pressLimit = correctOrder.Count;
	}

	public bool Correct(Tones tone)
	{
		bool toReturn = false;
		IncrementCurrentInput();
		if (correctOrder[correctInput] == tone)
		{
			correctInput++;
			toReturn = true;
		}
		else if(currentInput < pressLimit)
			toReturn = true;
		else
			toReturn = false;

		return toReturn;
	}

	private void IncrementCurrentInput()
	{
		currentInput++;
	}

	public bool Solved(Tones tone)
	{
		if (correctInput == pressLimit)
			return true;
		else
			return false;
	}

	public void Reset()
	{
		currentInput = 0;
		correctInput = 0;
	}
}
