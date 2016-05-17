using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BoardGameApi
{
    public class Position
    {
        public int horizontal;
        public int vertical;

        public Position(int horizontal, int vertical)
        {
            this.horizontal = horizontal;
            this.vertical = vertical;
        }

        public Position SumPos(Position pos)
        {
            Position newPosition;

            newPosition = new Position(
                    horizontal + pos.horizontal,
                    vertical + pos.vertical
                    );

            return newPosition;
        }

    }
}
