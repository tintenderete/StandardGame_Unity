using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BoardGameApi
{
    public abstract class Actor
    {
        static int idCount = 0;
        public enum types { Cell, Piece };
        protected int type;
        private int id;
        private int name;

        public static int GetCount() { return idCount; }
        public static void ResetCount() { idCount = 0; }

        public Actor()
        {
            id = idCount;
            idCount++;
        }

        public int Get_type()
        {
            return type;
        }

        public int GetId()
        {
            return id;
        }

        public int GetName()
        {
            return name;
        }

        public void SetName(int newName)
        {
            name = newName;
        }

        public bool IsActorCell()
        {
            if (this.type == (int)Actor.types.Cell)
            {
                return true;
            }

            return false;
        }

        public bool IsActorPiece()
        {
            if (this.type == (int)Actor.types.Piece)
            {
                return true;
            }

            return false;
        }

        public Cell TakeActorAsCell(Board board)
        {
            if (IsActorPiece())
            {
                return board.GetCell((Piece)this);
            }
            else
            {
                return (Cell)this;
            }
        }

    }
    
}
