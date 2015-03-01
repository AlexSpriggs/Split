using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CareTakerCubeRotations  
{
	private Dictionary<Cubes, Stack<Memento<Quaternion>>> CubesRotations =
		new Dictionary<Cubes, Stack<Memento<Quaternion>>>();

	private static CareTakerCubeRotations instance;

	public static CareTakerCubeRotations Instance
	{
		get { return instance ?? (instance = new CareTakerCubeRotations()); }
	}

	public void SaveState(Cubes cube)
	{
		if(ContainsKey(cube))
			CubesRotations[cube].Push(cube.CreateRotationMemento());
		else
		{
			Stack<Memento<Quaternion>> rotStack = new Stack<Memento<Quaternion>>();
			rotStack.Push(cube.CreateRotationMemento());
			CubesRotations.Add(cube, rotStack);
		}
	}

	public bool IsStackPopulated(Cubes cube)
	{
		if (CubesRotations[cube].Count == 0)
		{
			ClearCubeRotations(cube);
			return false;
		}
		else
			return true;
	}

	public void ClearCubeRotations(Cubes cube)
	{
		CubesRotations.Remove(cube);
	}

	public Quaternion RestoreState(Cubes cube)
	{
		return CubesRotations[cube].Pop().GetState();
	}

	public bool ContainsKey(Cubes cube)
	{
		if (CubesRotations.ContainsKey(cube))
			return true;
		else
			return false;
	}
}
