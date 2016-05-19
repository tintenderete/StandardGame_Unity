using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Curtain : ScriptableObject 
{
	
	private Text text;

	private static go_Curtain go_curtain;

	static public void On(float minTime, string textForCurtain)
	{
		go_curtain.CurtainOn (minTime, textForCurtain);
	}

	static public void On(string textForCurtain)
	{
		go_curtain.CurtainOn (textForCurtain);
	}

	static public void Off()
	{
		go_curtain.CurtainOff ();
	}
		
	public void CreateNewCurtain()
	{
		if (!ThereIsCanvas ()) 
		{
			NewCanvas ();
		}
			
		if (ThereIsCurtainControl ()) 
		{
			return;
		}

		NewCurtainControl ();
	}

	private bool ThereIsCanvas()
	{
		GameObject canvas = GameObject.Find("Canvas");

		if (canvas != null) 
		{
			return true;
		}

		return false;
	}



	private void NewCanvas()
	{
		
		GameObject canvas = new GameObject ("Canvas");
		Canvas c = canvas.AddComponent<Canvas> ();
		c.renderMode = RenderMode.ScreenSpaceOverlay;
		canvas.AddComponent<CanvasScaler> ();
		canvas.AddComponent<GraphicRaycaster> ();


	}

	private void NewCurtainControl()
	{
		GameObject canvas = GameObject.Find ("Canvas");

		Object resource = Resources.Load ("CurtainControl");

		GameObject curtain = Instantiate (resource) as GameObject;

		curtain.transform.SetParent (canvas.transform, false);
		curtain.name = "CurtainControl";

		go_curtain =  curtain.AddComponent<go_Curtain> ();


	}




	private bool ThereIsCurtainControl()
	{
		GameObject curtainControl = GameObject.Find ("CurtainControl");

		if (curtainControl) 
		{
			return true;
		}
		return false;
	}





}
