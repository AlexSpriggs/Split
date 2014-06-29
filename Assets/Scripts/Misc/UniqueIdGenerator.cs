using UnityEngine;
using System.Collections;

public class UniqueIdGenerator 
{
	private string uniqueId;
	private string space = "_";

	private static UniqueIdGenerator instance;

	public static UniqueIdGenerator Instance
	{
		get { return instance ?? (instance = new UniqueIdGenerator()); }
	}

	public string GeneratUniqueId(GameObject gameObject)
	{
		uniqueId = gameObject.name + space + Application.loadedLevelName + space + 
			(int)gameObject.transform.position.x + space + (int)gameObject.transform.position.y + 
			space + (int)gameObject.transform.position.z;
		return uniqueId;
	}
}
