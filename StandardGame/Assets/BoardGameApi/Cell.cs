using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BoardGameApi
{
    public class Cell: Actor
    {

        protected Position boardPosition;
        protected Piece currentPiece;

        public Cell()
        {
            this.type = (int)Actor.types.Cell;
        }

        public Cell(Position boardPosition, Piece piece)
        {
            this.boardPosition = boardPosition;
            this.currentPiece = piece;
            this.type = (int)Actor.types.Cell;
        }

        public Position GetBoardPosition()
        {
            return boardPosition;
        }

        public Piece GetPiece()
        {
            return currentPiece;
        }

        public void SetPiece(Piece newPiece)
        {
            this.currentPiece = newPiece;
        }

        public void SetEmptyCell()
        {
            this.currentPiece = new NoPiece();
        }

        public bool IsEmpty()
        {
            if (currentPiece.Get_type() == (int)Piece.colors.NoPiece)
            {
                return true;
            }
            return false;
        }
    }
}
