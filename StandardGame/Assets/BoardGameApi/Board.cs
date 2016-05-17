using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BoardGameApi
{
    public class Board
    {
        
        protected Position size = new Position(1,1);
        protected Cell[,] boardTable = new Cell[1, 1];

        public Board(Board board)
        {
            Actor.ResetCount();
            this.boardTable = board.GetBoard();
            size = board.GetSize();
        }

        public Board(Cell[,] board, int HorizontalSize, int VerticalSize)
        {
            Actor.ResetCount();
            this.boardTable = board;
            size.horizontal = HorizontalSize;
            size.vertical = VerticalSize;
        }
        public Board()
        {
            Actor.ResetCount();
        }

        public Cell[,] GetBoard()
        {
            return this.boardTable;
        }

        public Cell GetCell(int boardPosH, int boardPosV)
        {
            Cell cellToReturn;

            cellToReturn = boardTable[boardPosH, boardPosV];

            return cellToReturn;   
        }

        public Cell GetCell(Piece piece)
        {
            int pieceId = piece.GetId();
            int pieceId_i;
            foreach (Cell cell in boardTable)
            {
                pieceId_i = cell.GetPiece().GetId();
                if (pieceId == pieceId_i)
                {
                    return cell;
                }
            }
           
			return new Cell();
        }

        public Piece GetPiece(int boardPosH, int boardPosV)
        {
            Piece pieceToreturn;
            Cell cellContainer;

            cellContainer = GetCell(boardPosH, boardPosV);

            pieceToreturn = cellContainer.GetPiece();

            return pieceToreturn;
        }

        public Piece GetPiece(Cell cell)
        {
            Piece pieceToreturn;
            Position cellBoardPos;
            Cell cellContainer;

            cellBoardPos = cell.GetBoardPosition();

            cellContainer = GetCell(cellBoardPos.horizontal, cellBoardPos.vertical);

            pieceToreturn = cellContainer.GetPiece();

            return pieceToreturn;
        }

        public Position GetSize()
        {
            return size;
        }

        public void MovePiece(Cell origin, Cell destiny)
        {
            destiny.SetPiece(origin.GetPiece());
            origin.SetEmptyCell();
        }


        public bool IsPosOnTheBoard(Position position)
        {
            int sizeV = size.vertical;
            int sizeH = size.horizontal;

            if (position.vertical < 0 || position.vertical >= sizeV)
            {
                return false;
            }

            if (position.horizontal < 0 || position.horizontal >= sizeH)
            {
                return false;
            }


            return true;
        }

        

        public List<Cell> CellsInRange(Cell cell, List<Position> skillList)
        {
            List<Cell> nextCells = new List<Cell>();

            Position piecePosition = cell.GetBoardPosition();
            List<Position> pieceMovements = skillList;


            Position nextPosition;
            Cell nextCell;

            foreach (Position skill in pieceMovements)
            {
                nextPosition = piecePosition.SumPos(skill);

                if (IsPosOnTheBoard(nextPosition))
                {
                    nextCell = GetCell(nextPosition.horizontal, nextPosition.vertical);
                    nextCells.Add(nextCell);
                }
            }

            return nextCells;
        }

        public bool IsPlayerPiece(Cell cell, Player player)
        {
            int playerColor = player.GetColor();
            int pieceColor = cell.GetPiece().GetColor();

            if (playerColor == pieceColor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
