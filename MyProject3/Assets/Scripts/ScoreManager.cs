using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int Score = 0;
    int prevScore = 0;
	private void Awake()
	{
		if(SaveManager.Load() != null)
		{
			Score = SaveManager.Load(2);
		}
		else
		{
			Score = 0;
		}
		Debug.Log("AWAKESM" + Score);
	}
	private void Update()
	{
		if(prevScore != Score)
		{
			Score = Mathf.Max(0, Score);
			prevScore = Score;
		}
	}

	public void ResetScore()
	{
		Score = SaveManager.Load(2);
	}
}
