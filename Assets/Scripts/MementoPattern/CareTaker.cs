using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CareTaker 
{
	private List<Memento<SavedState>> mementos = new List<Memento<SavedState>>();

	private static CareTaker instance;
	
	public static CareTaker Instance
	{
		get { return instance ?? (instance = new CareTaker()); }
	}

	public void SaveState(PuzzleObject puzzleObject)
	{
		Memento<SavedState> memento = mementos.Find(m => m.GetState().ID == puzzleObject.ID);
		if (mementos.Contains(memento))
			mementos.Remove(memento);

		mementos.Add(puzzleObject.CreateMemento());
	}

	public void RestoreState(PuzzleObject puzzleObject)
	{
		puzzleObject.SetMemento(mementos.Find(m => m.GetState().ID == puzzleObject.ID));
	}

	public bool Exists(PuzzleObject puzzleObject)
	{
		if (mementos.Exists(m => m.GetState().ID == puzzleObject.ID))
			return true;
		else
			return false;
	}
}
