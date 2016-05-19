using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BoardGameApi
{
    class PiecesToMove_Standard
    {
       
		public List<Action> BasicMovementsAvailable(Player currentPlayer, Board board)
        {
			List<Action> movements = new List<Action> ();

            Cell[,] boardTable = board.GetBoard();
            Piece pieceAux;

            Action newMove;

            foreach (Cell cell in boardTable)
            {
                pieceAux = cell.GetPiece();

                if (board.IsPlayerPiece(cell, currentPlayer ))
                {
                    newMove = new Action(cell, board.CellsInRange(cell, cell.GetPiece().GetBasicMovement()));

                    if (newMove.destinyCells.Count != 0)
                    {
                        movements.Add(newMove);
                    }
                   
                }

            }

			return movements;
        }

        

       


    }
}
