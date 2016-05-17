using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BoardGameApi
{
	class PlayerPlay_Standard: MonoBehaviour, IStep
    {
        public Timer timer;
        public Action nextMovement;
        public List<Action> movementsAvailable;

        public Player currentPlayer;
        public List<Actor> inputs;
        private Board board;
        private TurnManager turnManager;

        public PlayerPlay_Standard(TurnManager turnManager)
        {
            this.timer = new Timer(30);
            this.movementsAvailable = new List<Action>();
            this.currentPlayer = new Player();
            this.inputs = new List<Actor>();
            this.board = new Board();
            this.turnManager = turnManager;
        }

		public PlayerPlay_Standard(float timeLimit)
        {
            this.timer = new Timer(timeLimit);
            this.movementsAvailable = new List<Action>();
            this.currentPlayer = new Player();
            this.inputs = new List<Actor>();
            this.board = new Board();   

        }

        public void UpdateStep(TurnManager turnManager)
        {
            
            this.turnManager = turnManager;
            

            currentPlayer = turnManager.GetGame().GetCurrentPlayer();
            inputs = currentPlayer.GetInputs();
            board = turnManager.GetGame().GetBoard();

            this.nextMovement = DidPlayerDoAnyMovementAvailable();
            
            
            if (this.nextMovement != null)
            {
                currentPlayer.SetZeroInputs();

                turnManager.GetGame().GetBoard().MovePiece(nextMovement.originCell, nextMovement.destinyCells[0]);

                turnManager.NextStep();

                return;
            }

            if (timer.TimeOff())
            {
                turnManager.NextStep();
                timer.ResetTime();
            }


        }

        
        
        
        
        public Cell TakeActorAsCell(Actor actor)
        {
			
            if (actor.IsActorPiece())
            {
				
				Piece piece = (Piece)actor;
                return turnManager.GetGame().GetBoard().GetCell(piece);

            }
            else
            {
                return (Cell)actor;
            }
        }

        public Action DidPlayerDoAnyMovementAvailable()
        {
            Cell destinyCell = null;

            for (int i = inputs.Count - 1; i >= 0; i--)
            {
                Cell cell = TakeActorAsCell(inputs[i]);
				Debug.Log ("id:::::" + cell.GetPiece().GetId()); // correcta la id
                if (destinyCell == null)
                {
                    if (board.IsPlayerPiece(cell, currentPlayer))
                    {
                        if (Action.IsCellInAnyOrigin(cell, movementsAvailable))
                        {
                            inputs =  Tools.ClearListBut(cell, inputs);
							Debug.Log ("id222222:   " + cell.GetPiece().GetId()); // correcta la id
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
								Debug.Log ("id333333:   " + cell.GetPiece().GetId()); // correcta la id
								action = new Action(cell, new List<Cell>() { destinyCell });
								Debug.Log ("id444444:   " + action.originCell.GetPiece().GetId());// correcta la id
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






    }
}
