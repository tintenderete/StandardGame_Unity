using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class WaitingForPlayerPlay : IStep 
{
	
	private List<Action> movementsAvailable;

	public Action nextMovement;

	public WaitingForPlayerPlay()
	{
		movementsAvailable = new List<Action> ();

	}

	public void UpdateStep(TurnManager turnManager)
	{
		Curtain.Off ();

		nextMovement = null;

		if (!Curtain.IsActive()) 
		{
			if (go_Timer.IsTimeOff ()) 
			{
				go_Timer.ResetTime ();
				turnManager.NextStep ();
			}
		}

		movementsAvailable = turnManager.FindOneStepLike<MovementsAvailable> ().movements;

		nextMovement = Tools_PlayerPlay.DidPlayerDoAnyMovementAvailable (
			turnManager.GetGame().GetCurrentPlayer(), 
			turnManager.GetGame().GetCurrentPlayer().GetInputs(),
			movementsAvailable,
			turnManager.GetGame().GetBoard());

		if (nextMovement != null) 
		{
			go_Timer.ResetTime ();
			turnManager.NextStep ();
		}
		
	}
}
