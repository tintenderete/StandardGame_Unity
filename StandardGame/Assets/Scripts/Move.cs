using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class Move : IStep
{
	ListPieceManager go_pieces;
	Action playerPlay;

	int idPieceToMove;
	Position nextBoardPosition;

	public Move(ListPieceManager listPieceManager)
	{	
		go_pieces = listPieceManager;
	}


	public void UpdateStep(TurnManager turnManager)
	{

		playerPlay = turnManager.FindOneStepLike<WaitingForPlayerPlay> ().nextMovement;

		if (playerPlay == null) 
		{
			turnManager.NextStep ();
			return;
		}

		idPieceToMove = playerPlay.originCell.GetPiece ().GetId ();

		nextBoardPosition = playerPlay.destinyCells [0].GetBoardPosition ();

		go_pieces.DestroyPiece (playerPlay.destinyCells[0].GetPiece().GetId());

		go_pieces.MovePiece (idPieceToMove, nextBoardPosition);

		turnManager.GetGame ().GetBoard ().MovePiece (playerPlay.originCell, playerPlay.destinyCells[0]);

		turnManager.NextStep ();
	}
}
