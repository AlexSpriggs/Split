using UnityEngine;
using System.Collections;

public struct SavedState
{
	private bool locked;
	public bool Locked
	{
		get { return locked; }
	}

	private Vector3 position;
	public Vector3 Position
	{
		get { return position; }
	}

	private Quaternion rotation;
	public Quaternion Rotation
	{
		get { return rotation; }
	}

	private string id;
	public string ID
	{
		get { return id; }
	}

	private LayerMask layer;

	public LayerMask Layer
	{
		get { return layer; }
	}
	public SavedState(PuzzleObject puzzleObject)
	{
		locked = puzzleObject.Locked;
		position = puzzleObject.gameObject.transform.position;
		rotation = puzzleObject.gameObject.transform.rotation;
		id = puzzleObject.ID;
		layer = puzzleObject.gameObject.layer;
	}
}
