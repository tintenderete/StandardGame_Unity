using System;
using System.Collections.Generic;


namespace BoardGameApi
{
	class Tools_PlayerPlay 
	{
		

		static public Cell TakeActorAsCell(Actor actor, Board board)
		{
			
			if (actor.IsActorPiece())
			{

				Piece piece = (Piece)actor;
				return board.GetCell(piece);

			}
			else
			{
				return (Cell)actor;
			}
		}

		//End TakeActorAsCell

		static public Action DidPlayerDoAnyMovementAvailable(Player currentPlayer, List<Actor> inputs, List<Action> movementsAvailable, Board board)
		{
			Cell destinyCell = null;

			for (int i = inputs.Count - 1; i >= 0; i--)
			{
				Cell cell = TakeActorAsCell(inputs[i], board);

				if (destinyCell == null)
				{
					if (board.IsPlayerPiece(cell, currentPlayer))
					{
						if (Action.IsCellInAnyOrigin(cell, movementsAvailable))
						{
							inputs =  Tools.ClearListBut(cell, inputs);

							return null;
						}
						else
						{
							inputs = Tools.ClearList(inputs);
							return null;
						}
					}
					else
					{
						destinyCell = cell;
					}
				}
				else
				{
					if (board.IsPlayerPiece(cell, currentPlayer))
					{
						if (Action.IsCellInAnyOrigin(cell, movementsAvailable))
						{
							Action action = Action.FindActionByOriginCell(cell, movementsAvailable);

							if (action.IsCellInDestiny(destinyCell))
							{
								currentPlayer.SetZeroInputs();
								inputs = Tools.ClearList(inputs);

								action = new Action(cell, new List<Cell>() { destinyCell });

								return action;
							}
							else
							{
								inputs = Tools.ClearListBut(cell, inputs);
								return null;
							}
						}
						else
						{
							inputs = Tools.ClearList(inputs);
							return null;
						}
					}
					else
					{
						continue;
					}
				}
			}

			inputs = Tools.ClearList(inputs);
			return null;
		}

		// End DidPlayerDoAnyMovementAvailable

		static public List<Action> BasicMovementsAvailable(Player currentPlayer, Board board)
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

		//End  BasicMovementsAvailable
	}
}
