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
		PieceManager pieceManager;

		for (int h = 0; h < board.GetSize ().horizontal; h++) 
		{
			for (int v = 0; v < board.GetSize ().vertical; v++) 
			{
				piece = board.GetPiece (h, v);
				id = piece.GetId ();
				color = piece.GetColor ();

				if (color == (int)Piece.colors.White) 
				{
					pieceManager = new PieceManager (goFactory.MakeActor(Factory_goStandard.names.WhitePiece, piece, game ));
					piecesList [id] = pieceManager;
				} 
				else 
				{
					pieceManager = new PieceManager (goFactory.MakeActor(Factory_goStandard.names.BlackPiece, piece, game));
					piecesList [id] = pieceManager;
				}


			}
		}
	}

	public void MovePiece(int idPiece ,Vector2 destiny)
	{
		piecesList [idPiece].transform.position = new Vector3 (
			destiny.x,
			piecesList [idPiece].transform.position.y , 
			destiny.y);
	}

	public void DestroyPiece(int id)
	{
		Destroy (piecesList [id].go);
	}

}


