using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class go_Menu : MonoBehaviour 
{
	private static Text menuText;
	private static GameObject panel;

	// Use this for initialization
	void Start () 
	{
		menuText = gameObject.transform.Find ("Panel").Find("Text").GetComponent<Text> ();
		panel = gameObject.transform.Find ("Panel").gameObject;
		panel.gameObject.SetActive (false);
	}

	public static void MenucAtive(string winner)
	{
		SetText (winner);
		panel.gameObject.SetActive (true);
	}

	private static void SetText(string winner)
	{
		menuText.text = "Winner: " + winner;
	}
		

	public void QuitGame()
	{
		Application.Quit ();
	}


	

}
