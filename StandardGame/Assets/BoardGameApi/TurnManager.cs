using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BoardGameApi
{
    public class TurnManager
    {
        private List<IStep> steps;
        private int currentStep;
        private Game game;

        public TurnManager(Game newGame)
        {
            this.currentStep = 0;
            steps = new List<IStep>();
            game = newGame;
        }

        public TurnManager()
        {
            this.currentStep = 0;
            steps = new List<IStep>();
            game = null;
        }

        public void AddStep(IStep step)
        {
            steps.Add(step);
        }

        public void Update()
        {
            steps[currentStep].UpdateStep(this);  
        }

        public List<IStep> GetSteps()
        {
            return this.steps;
        }

        public IStep GetStep(int listPos)
        {
            return steps[listPos];
        }

        public void NextStep()
        {
            currentStep++;
            if (currentStep >= steps.Count)
            {
                currentStep = 0;
            }
        }

        public void NextStep(int nextStep)
        {
            currentStep = nextStep;
        }

        public int GetCurrentStep()
        {
            return currentStep;
        }

        public Game GetGame()
        {
            return game;
        }

        public void SetGame(Game game)
        {
             this.game = game ;
        }

        public T FindTheNextStepLike<T>()
        {
            
            for (int i = currentStep + 1; i < steps.Count; i ++)
            {
                if (steps[i] is T)
                {
                    return (T)steps[i];
                }
            }

            return default(T); 
        }

        public T FindOneStepLike<T>()
        {

            for (int i = 0; i < steps.Count; i++)
            {
                if (steps[i] is T)
                {
                    return (T)steps[i];
                }
            }

            return default(T);
        }

    }
}
