using UnityEngine;
using System.Collections;

public class Testing : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Factory_goStandard factory = new Factory_goStandard ();

		factory.MakeActor (Factory_goStandard.names.WhitePiece, null , null);
	
	}
	

}
