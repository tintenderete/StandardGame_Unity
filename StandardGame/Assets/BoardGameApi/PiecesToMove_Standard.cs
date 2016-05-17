using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BoardGameApi
{
    class PiecesToMove_Standard: IStep
    {
        private Board board;
        private Player currentPlayer;

        public List<Action> movements;

        public PiecesToMove_Standard(Board board, Player currentPlayer)
        {
            this.board = board;
            movements = new List<Action>();
            this.currentPlayer = currentPlayer;
        }

        public PiecesToMove_Standard()
        {
            movements = new List<Action>();
        }


        public void UpdateStep(TurnManager turnManager)
        {
            board = turnManager.GetGame().GetBoard();
            currentPlayer = turnManager.GetGame().GetCurrentPlayer();

            BasicMovementsAvailable();

            //int currentStep = turnManager.GetCurrentStep();
            //List<IStep> steps = turnManager.GetSteps();

            //PlayerPlay_Standard nextStep = (PlayerPlay_Standard)steps[currentStep + 1];

            PlayerPlay_Standard nextStep = turnManager.FindTheNextStepLike<PlayerPlay_Standard>();

            nextStep.movementsAvailable = movements;

            turnManager.NextStep();
            

        }


        public void BasicMovementsAvailable()
        {
            movements.Clear();

            Cell[,] boardTable = this.board.GetBoard();
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
                        newMove.NoPlayerCellsInDestiny(currentPlayer);
                        movements.Add(newMove);
                    }
                   
                }

            }
        }

        

       


    }
}
