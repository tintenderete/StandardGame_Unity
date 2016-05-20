using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BoardGameApi
{
    class BoardGameFactory
    {
        public enum names { Standard, BigStandard, AllWhitePieces, AllBlackPieces, AllNoPieces };

        public BoardGameFactory()
        {
        }

        public Board MakeBoard(int boardName)
        {
            if (boardName == (int)names.Standard)
            {
                return new StandardBoardGame();
            }

            if (boardName == (int)names.AllWhitePieces)
            {
                BoardTableEditor editor = new BoardTableEditor(8, 8, new StandardPieceFactory());

                for (int i = 0; i < 8; i++)
                {
                    editor.SetPointerInLine(i);

                    editor.PushPiece(8, (int)StandardPieceFactory.names.standard_White);
                }

                return editor.GetBoard();
            }

            if (boardName == (int)names.AllBlackPieces)
            {
                BoardTableEditor editor = new BoardTableEditor(8, 8, new StandardPieceFactory());

                for (int i = 0; i < 8; i++)
                {
                    editor.SetPointerInLine(i);

                    editor.PushPiece(8, (int)StandardPieceFactory.names.standard_Black);
                }

                return editor.GetBoard();
            }

            if (boardName == (int)names.AllNoPieces)
            {
                BoardTableEditor editor = new BoardTableEditor(8, 8, new StandardPieceFactory());

                for (int i = 0; i < 8; i++)
                {
                    editor.SetPointerInLine(i);

                    editor.PushPiece(8, (int)StandardPieceFactory.names.NoPiece);
                }

                return editor.GetBoard();
            }

			if (boardName == (int)names.BigStandard) 
			{
				BoardTableEditor editor = new BoardTableEditor (8, 6, new StandardPieceFactory());

				editor.SetPointerInLine (0);
				editor.PushPiece(8, (int)StandardPieceFactory.names.standard_White);
				editor.SetPointerInLine (1);
				editor.PushPiece(8, (int)StandardPieceFactory.names.standard_White);

				editor.SetPointerInLine (2);
				editor.PushPiece(8, (int)StandardPieceFactory.names.NoPiece);
				editor.SetPointerInLine (3);
				editor.PushPiece(8, (int)StandardPieceFactory.names.NoPiece);

				editor.SetPointerInLine (4);
				editor.PushPiece(8, (int)StandardPieceFactory.names.standard_Black);
				editor.SetPointerInLine (5);
				editor.PushPiece(8, (int)StandardPieceFactory.names.standard_Black);

				return editor.GetBoard ();

			}

            return new Board();
        }


    }

}