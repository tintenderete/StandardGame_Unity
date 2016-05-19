using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class go_Curtain : MonoBehaviour 
{
	private bool coroutine;

	private Text text;

	private GameObject curtain;

	void Start()
	{
		curtain = GetCurtain ();
		text = GetText ();
	}


	private Text GetText()
	{
		Text text = curtain.GetComponentInChildren<Text> ();
		if (text != null) 
		{
			return text;
		}
		return null;
	}

	private GameObject GetCurtain()
	{
		GameObject curtain = this.gameObject.transform.Find ("Curtain").gameObject;

		return curtain;
	}


	public void CurtainOff()
	{
		if (coroutine) 
		{
			return;
		}

		text.text = "";
		curtain.SetActive(false);
	}

	public void CurtainOn(string textForCurtain)
	{
		text.text = textForCurtain;
		curtain.SetActive(true);
	}

	public IEnumerator CurtainOn_coroutine(float minTime, string textForCurtain)
	{
		coroutine = true;
		CurtainOn(textForCurtain);

		yield return new WaitForSeconds(minTime);

		coroutine = false;
		CurtainOff ();


	}

	public void CurtainOn(float minTime, string textForCurtain)
	{
		StartCoroutine (CurtainOn_coroutine(minTime, textForCurtain));
	}
}
