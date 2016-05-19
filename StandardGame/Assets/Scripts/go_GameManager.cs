using UnityEngine;
using System.Collections;
using BoardGameApi;

public class go_GameManager : MonoBehaviour 
{
	Game game;
	ListCellManager listCellsManager;
	ListPieceManager  listPieceManager;

	Board board;
	TurnManager turnManager;

	// Use this for initialization
	void Start () 
	{
		BoardGameFactory boardGameFactory = new BoardGameFactory ();

		board = boardGameFactory.MakeBoard ((int)BoardGameFactory.names.Standard);
		turnManager = new TurnManager ();

		game = new Game (board, turnManager);

		listCellsManager = new ListCellManager ();
		listPieceManager = new ListPieceManager ();

		listCellsManager.NewBoardTable (game);
		listPieceManager.NewList (game);
		/*
		turnManager.AddStep (new PiecesToMove_Standard());
		turnManager.AddStep (new PlayerPlay_Standard(5000));
		turnManager.AddStep (new Move(listPieceManager));
		turnManager.AddStep (new VictoryCondition());
		*/
		turnManager.SetGame (game);

	}
	
	// Update is called once per frame
	void Update () 
	{
		game.Update ();
	}
}
