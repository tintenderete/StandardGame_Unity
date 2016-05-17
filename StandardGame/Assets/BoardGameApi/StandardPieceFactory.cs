using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BoardGameApi
{
    class StandardPieceFactory: IPieceFactory
    {
        public enum names { NoPiece, standard_White, standard_Black };

        public Piece MakePiece(int pieceName)
        {
            Piece newPiece;
            List<Position> movementSkill = new List<Position>();

            if (pieceName == (int)names.standard_White)
            {
                movementSkill.Add(new Position(0, 1));
                movementSkill.Add(new Position(0, -1));
                movementSkill.Add(new Position(1, 0));
                movementSkill.Add(new Position(-1, 0));

                newPiece = new Piece((int)Piece.colors.White, movementSkill);

                return newPiece;
            }
            if (pieceName == (int)names.standard_Black)
            {
                movementSkill.Add(new Position(0, 1));
                movementSkill.Add(new Position(0, -1));
                movementSkill.Add(new Position(1, 0));
                movementSkill.Add(new Position(-1, 0));

                newPiece = new Piece((int)Piece.colors.Black, movementSkill);

                return newPiece;
            }

            return new Piece((int)Piece.colors.NoPiece, movementSkill);



        }
    }
}
