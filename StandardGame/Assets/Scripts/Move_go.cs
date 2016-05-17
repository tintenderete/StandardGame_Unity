using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class Move_go : IStep
{
	ListPieceManager pieces;
	Action playerPlay;

	int idPiece;
	Position nextBoardPosition;

	public Move_go(ListPieceManager listPieceManager)
	{	
		pieces = listPieceManager;
	}


	public void UpdateStep(TurnManager turnManager)
	{
	
		playerPlay = turnManager.FindOneStepLike<PlayerPlay_Standard> ().nextMovement;
		Debug.Log ("i5555554:   " + playerPlay.originCell.GetPiece().GetId());// correcta la id
		if (playerPlay == null) 
		{
			turnManager.NextStep ();
			return;
		}

		idPiece = playerPlay.originCell.GetPiece ().GetId ();
		nextBoardPosition = playerPlay.destinyCells [0].GetBoardPosition ();

		pieces.MovePiece (idPiece, nextBoardPosition);

		turnManager.NextStep ();
	}
}
