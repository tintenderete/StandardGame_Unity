using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class MovementsAvailable : IStep 
{
	

	public List<Action> movements;

	public MovementsAvailable()
	{
		movements = new List<Action> ();

	}

	public void UpdateStep(TurnManager turnManager)
	{

		Curtain.On (
			2f,
			turnManager.GetGame().GetCurrentPlayerName()
		);

		movements = new List<Action> ();

		movements = Tools_PlayerPlay.BasicMovementsAvailable (
			turnManager.GetGame().GetCurrentPlayer(),
			turnManager.GetGame().GetBoard()
		);

		foreach (Action action in movements) 
		{
			action.NoPlayerCellsInDestiny (turnManager.GetGame ().GetCurrentPlayer ());
		}

		turnManager.NextStep ();
			
	}
}
