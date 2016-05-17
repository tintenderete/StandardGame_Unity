using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BoardGameApi
{
    public class Game
    {
        private Player[] players;
        private int currentPlayer;
        private Board board;
        private TurnManager turnManager;

        public Game(Board board, TurnManager turnManager )
        {
            this.board = board;
            this.turnManager = turnManager;
            this.currentPlayer = 0;
            SetPlayers();
        }

        public void Update()
        {
            turnManager.Update();
        }
        public Player GetCurrentPlayer()
        {
            return players[currentPlayer];
        }

        public Board GetBoard()
        {
            return this.board;
        }

        public TurnManager GetTurnManager()
        {
            return this.turnManager;
        }

        public void NexPlayer()
        {
            currentPlayer++;
            if (currentPlayer == players.LongLength)
            {
                currentPlayer = 0;
            }
        }

        public void SetPlayers()
        {
            players = new Player[2];
            players[0] = new Player((int)Player.colors.White);
            players[1] = new Player((int)Player.colors.Black);
        }

    }
}
