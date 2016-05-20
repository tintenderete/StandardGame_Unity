using UnityEngine;
using System.Collections;
using BoardGameApi;
using UnityEngine.UI;

public class go_Timer : MonoBehaviour 
{
	private static Timer timer;
	private static Slider timerBar;
	private static float valueForBar;

	void Start () 
	{
		timer = new Timer (1000f);
		timerBar = GameObject.Find ("TimerControl").transform.Find ("Slider").GetComponent<Slider> ();
	}

	public static bool IsTimeOff()
	{
		bool result;

		if (timer.TimeOff ()) {
			result = true;
		} else {
			result = false;
		}

		CalculateValue ();
		UpdateControl ();

		return result;
	}

	public static void ResetTime()
	{
		timer.ResetTime ();
	}

	public static void SetLimitTime(float timeLimit)
	{
		timer.timeLimit = timeLimit;
	}

	private static void CalculateValue()
	{
		valueForBar = timer.count / timer.timeLimit;
	}
		
	private static void UpdateControl()
	{
		timerBar.value = valueForBar;
	}
		
	// Use this for initialization



}
