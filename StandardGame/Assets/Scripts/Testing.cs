using UnityEngine;
using System.Collections;

public class Testing : MonoBehaviour {

	Curtain curtain ;
	// Use this for initialization
	void Start () 
	{
		curtain = Curtain.CreateInstance<Curtain> ();
		curtain.CreateNewCurtain ();



	}

	void Update(){
		
		
		Curtain.On ("HOOOOOLA");
		curtain.CreateNewCurtain ();
	}
	

}
