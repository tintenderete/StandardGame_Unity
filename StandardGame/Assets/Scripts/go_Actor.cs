using UnityEngine;
using System.Collections;
using BoardGameApi;


public class go_Actor : MonoBehaviour 
{
	public Actor actor;
	public Game game;


	void OnMouseDown()
	{
		if (game == null || game.GetCurrentPlayer() == null)
			return;
		
		
		this.game.GetCurrentPlayer ().AddInput (actor);
	}

	public void SetSettings(Actor actor, Game game)
	{
		this.actor = actor;
		this.game = game;
	}
}
