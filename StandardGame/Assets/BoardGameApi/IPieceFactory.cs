using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BoardGameApi
{
    public interface IPieceFactory
    {
        Piece MakePiece(int pieceName);
    }
}
