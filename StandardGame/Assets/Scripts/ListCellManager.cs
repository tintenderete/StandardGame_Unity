using UnityEngine;
using System.Collections;
using BoardGameApi;

public class ListCellManager
{
	public CellManager[,] boardTable;

	public ListCellManager()
	{
	}

	public void NewBoardTable(Game game)
	{
		Factory_goStandard goFactory = new Factory_goStandard();
		Board board = game.GetBoard ();
		boardTable = new CellManager[board.GetSize ().horizontal, board.GetSize ().vertical];
		Cell cell;
		CellManager cellManager;

		for (int h = 0; h < board.GetSize ().horizontal; h++) 
		{
			for (int v = 0; v < board.GetSize ().vertical; v++) 
			{
				cell = board.GetCell (h, v);
				cellManager = new CellManager (goFactory.MakeActor(Factory_goStandard.names.Cell, cell, game));
				boardTable [h, v] = cellManager;

				boardTable [h, v].transform.position = new Vector3 (
					(float)v,
					(float)boardTable [h, v].transform.position.y,
					(float)h);
			}
		}
	}



}
