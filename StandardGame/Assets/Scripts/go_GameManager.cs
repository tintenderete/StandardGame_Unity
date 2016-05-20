using UnityEngine;
using System.Collections;
using BoardGameApi;

public class go_GameManager : MonoBehaviour 
{
	Curtain curtain;
	Game game;
	ListCellManager listCellsManager;
	ListPieceManager  listPieceManager;

	Board board;
	TurnManager turnManager;

	private void NewGame()
	{
		curtain = Curtain.CreateInstance<Curtain> ();
		curtain.CreateNewCurtain ();

		BoardGameFactory boardGameFactory = new BoardGameFactory ();

		board = boardGameFactory.MakeBoard ((int)BoardGameFactory.names.BigStandard);
		turnManager = new TurnManager ();

		game = new Game (board, turnManager);

		listCellsManager = new ListCellManager ();
		listPieceManager = new ListPieceManager ();

		listCellsManager.NewBoardTable (game);
		listPieceManager.NewList (game);

		turnManager.AddStep (new MovementsAvailable());
		turnManager.AddStep (new WaitingForPlayerPlay());
		turnManager.AddStep (new Move(listPieceManager));
		turnManager.AddStep (new VictoryCondition());

		turnManager.SetGame (game);
	}

	// Use this for initialization
	void Start () 
	{
		
		NewGame ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		game.Update ();
	}


}
