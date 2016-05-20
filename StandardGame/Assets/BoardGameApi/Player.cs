using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BoardGameApi
{
    public class Player
    {
        public enum colors {NoPiece, White, Black};

        private static List<Actor> inputs;

        private int color;

        public Player()
        {
            if (inputs == null)
            {
                inputs = new List<Actor>();
            }

        }

        public Player(int color)
        {
            if (inputs == null)
            {
                inputs = new List<Actor>();
            }

            this.color = color;
        }

        public int GetColor()
        {
            return color;
        }

        public void AddInput(Actor actor)
        {
            inputs.Add(actor);
        }

        public List<Actor> GetInputs()
        {
            return inputs;
        }

        public void SetInputs(List<Actor> newInputs)
        {
            inputs.Clear();
            foreach (Actor actor in newInputs)
            {
                inputs.Add(actor);
            }
        }

        public void SetZeroInputs()
        {
            inputs.Clear();
        }
    }
}
