using UnityEngine;
using System.Collections;
using BoardGameApi;

public class VictoryCondition : IStep 
{

	public VictoryCondition()
	{
	}

	public void UpdateStep(TurnManager turnManager)
	{
		if (NoEnemyPieces.Control (turnManager.GetGame ().GetBoard (), turnManager.GetGame ().GetCurrentPlayer ())) 
		{
			go_Menu.MenucAtive (turnManager.GetGame ().GetCurrentPlayerName ());
		}
		else 
		{
			turnManager.GetGame ().NexPlayer ();
			turnManager.NextStep ();
		}
		
	}
}
