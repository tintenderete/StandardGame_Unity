using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BoardGameApi
{
    class PlayerPlay_Standard: IStep
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

        public PlayerPlay_Standard()
        {
            this.timer = new Timer(30);
            this.movementsAvailable = new List<Action>();
            this.currentPlayer = new Player();
            this.inputs = new List<Actor>();
            this.board = new Board();   
        }

        public void UpdateStep(TurnManager turnManager)
        {
            if (turnManager == null)
            {
                this.turnManager = turnManager;
            }

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
                return turnManager.GetGame().GetBoard().GetCell((Piece)actor);
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
                                return action = new Action(cell, new List<Cell>() { destinyCell });
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
