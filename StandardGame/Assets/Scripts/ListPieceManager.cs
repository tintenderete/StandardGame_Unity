using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class ListPieceManager :ScriptableObject
{
	public List<PieceManager> piecesList;



	public ListPieceManager()
	{
		this.piecesList = new List<PieceManager> ();

	}

	public void NewList(Game game)
	{
		Factory_goStandard goFactory = new Factory_goStandard();
		Board board = game.GetBoard ();
		Piece piece;
		int id;
		int color;
		PieceManager newPieceManager;

		for (int h = 0; h < board.GetSize ().horizontal; h++) 
		{
			for (int v = 0; v < board.GetSize ().vertical; v++) 
			{
				piece = board.GetPiece (h, v);
				id = piece.GetId ();
				color = piece.GetColor ();

				if(color == (int)Piece.colors.NoPiece){continue;}

				if (color == (int)Piece.colors.White) 
				{
					newPieceManager = new PieceManager (goFactory.MakeActor(Factory_goStandard.names.WhitePiece, piece, game ));

				} 
				else 
				{
					newPieceManager = new PieceManager (goFactory.MakeActor(Factory_goStandard.names.BlackPiece, piece, game));

				}

				newPieceManager.transform.position = new Vector3 (
					v,
					newPieceManager.transform.position.y, 
					h);
				
				newPieceManager.id = id;

				piecesList.Add (newPieceManager);
			}
		}
	}

	public void MovePiece(int idPiece , Position newPosition)
	{
		
		foreach (PieceManager pieceManager in piecesList) 
		{
			
			if (pieceManager.id == idPiece) 
			{
				
				pieceManager.go.transform.position = new Vector3
				(
					newPosition.vertical,
					pieceManager.transform.position.y , 
					newPosition.horizontal
				);
			}
		}


	}

	public void DestroyPiece(int idPiece)
	{
		foreach (PieceManager pieceManager in piecesList) 
		{
			if (pieceManager.id == idPiece) 
			{
				Destroy (pieceManager.go);
			}
		}
	}

}


