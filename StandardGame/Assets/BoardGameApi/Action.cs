using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BoardGameApi
{
    public class Action
    {

        public static bool IsCellInAnyOrigin(Cell cell, List<Action> actionList)
        {
            for (int i = 0; i < actionList.Count; i++)
            {
                if (cell == actionList[i].originCell)
                {
                    return true;
                }
            }

            return false;
        }

        public static Action FindActionByDestinyCell(Cell cell, List<Action> actionList)
        {
            for (int i = 0; i < actionList.Count; i++)
            {
                for (int j = 0; j < actionList[i].destinyCells.Count; j++)
                {
                    if (actionList[i].destinyCells[j] == cell)
                    {
                        return actionList[i];
                    }
                }
            }

            return null;
        }

        public static Action FindActionByOriginCell(Cell cell, List<Action> actionList)
        {
            for (int i = 0; i < actionList.Count; i++)
            {
                if (cell == actionList[i].originCell)
                {
                    return actionList[i];
                }
            }

            return null;
        }

        public Cell originCell;
        public List<Cell> destinyCells;

        public Action(Cell currentCell)
        {
            this.originCell = currentCell;
            this.destinyCells = new List<Cell>();
        }

        public Action(Cell currentCell, List<Cell> nextCells)
        {
            this.originCell = currentCell;
            this.destinyCells = nextCells;
        }
        
        public bool IsCellInOrigin(Cell cell)
        { 
            if (originCell == cell)
            {
                return true;
            }
            return false;
        }

        public bool IsCellInDestiny(Cell cell)
        {
            foreach (Cell destinycell in destinyCells)
            {
                if (destinycell == cell)
                {
                    return true;
                }
            }
            return false;
        }


        public void NoPlayerCellsInDestiny(Player player)
        {
            int playerColor = player.GetColor();
            int pieceColor;

            List<Cell> cellsToRemove = new List<Cell>();

            for (int i = 0; i < destinyCells.Count; i++)
            {
                pieceColor = destinyCells[i].GetPiece().GetColor();

                if (pieceColor == playerColor)
                {
                    cellsToRemove.Add(destinyCells[i]);
                }
            }

            for (int i = 0; i < cellsToRemove.Count; i++)
            {
                destinyCells.Remove(cellsToRemove[i]);
            }
        }


        

    }
}
