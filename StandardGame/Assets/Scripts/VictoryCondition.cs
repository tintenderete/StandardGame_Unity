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
			Debug.Log ("WINNER");
		}
		else 
		{
			Debug.Log ("TURN FINISED");
			turnManager.GetGame ().NexPlayer ();
			turnManager.NextStep ();
		}
		
	}
}
