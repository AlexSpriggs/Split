using UnityEngine;
using System.Collections;

public class PuzzleObject : MonoBehaviour 
{
	protected SavedState state;

	public string ID;

	protected bool locked;
	public bool Locked { get { return locked; } }

	protected virtual void Awake()
	{
		ID = UniqueIdGenerator.Instance.GeneratUniqueId(gameObject);
	}

	protected virtual void Start()
	{
		if (CareTaker.Instance.Exists(this))
			CareTaker.Instance.RestoreState(this);

		Debug.Log("ID of object: " + ID);
	}

	public Memento<SavedState> CreateMemento()
	{
		Memento<SavedState> m = new Memento<SavedState>();
		m.SetState(state);
		return m;
	}


	public void SetMemento(Memento<SavedState> m)
	{
		state = m.GetState();
		gameObject.transform.position = state.Position;
		locked = state.Locked;
		gameObject.layer = state.Layer;
	}

	public void SetState(PuzzleObject state)
	{
		this.state = new SavedState(this);
	}

	protected void saveState()
	{
		SetState(this);
		CareTaker.Instance.SaveState(this);
	}
}
