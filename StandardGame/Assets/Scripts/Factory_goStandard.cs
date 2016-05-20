using UnityEngine;
using System.Collections;
using BoardGameApi;

public class Factory_goStandard : ScriptableObject 
{

	public enum names {BlackPiece, WhitePiece, Cell};

	public Factory_goStandard()
	{
	}

	public GameObject MakeActor(names name, Actor actor, Game game)
	{
		Object resource;
		GameObject newGameObject;

		if (name == names.WhitePiece) 
		{
			resource = Resources.Load ("WhitePiece");

			newGameObject = Instantiate (resource) as GameObject;

			newGameObject.transform.GetChild (0).gameObject.AddComponent<go_Piece>().SetSettings(actor, game);

			return newGameObject;
		}

		if (name == names.BlackPiece) 
		{
			resource = Resources.Load ("BlackPiece");

			newGameObject = Instantiate (resource) as GameObject;

			newGameObject.transform.GetChild (0).gameObject.AddComponent<go_Piece>().SetSettings(actor, game);

			return newGameObject;
		}
		if (name == names.Cell) 
		{
			resource = Resources.Load ("Cell");

			newGameObject = Instantiate (resource) as GameObject;

			newGameObject.transform.GetChild (0).gameObject.AddComponent<go_Cell>().SetSettings(actor, game);

			return newGameObject;
		}

		return null;
	}


}
