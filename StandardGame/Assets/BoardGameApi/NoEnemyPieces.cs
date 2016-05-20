using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BoardGameApi
{
    class NoEnemyPieces
    {
        public static bool Control(Board board , Player currentPlayer)
        {
            int horizontal = board.GetSize().horizontal;
            int vertical = board.GetSize().vertical;
            Cell[,] boardTable = board.GetBoard();


            int colorCurrentPlayer = currentPlayer.GetColor();
            int colorAux;


            for (int v = 0; v < vertical; v++)
            {
                for (int h = 0; h < horizontal; h++)
                {
                    colorAux = boardTable[h,v].GetPiece().GetColor();

                    if (colorAux == (int)Player.colors.NoPiece){ continue; }
                    if (colorAux != colorCurrentPlayer) { return false; }
                }
            }


            return true;
            
        }
    }
}
