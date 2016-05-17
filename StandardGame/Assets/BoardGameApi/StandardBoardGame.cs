using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BoardGameApi
{
    class StandardBoardGame: Board
    {

        public StandardBoardGame()
        {
            BoardTableEditor editor = new BoardTableEditor(3, 3, new StandardPieceFactory());

            editor.SetPointerInLine(0);
            editor.PushPiece(3, (int)StandardPieceFactory.names.standard_White);

            editor.SetPointerInLine(2);
            editor.PushPiece(3, (int)StandardPieceFactory.names.standard_Black);

            boardTable = editor.GetBoard().GetBoard();
            size = new Position(3, 3);
        }
    }
}
