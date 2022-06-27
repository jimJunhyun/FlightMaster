using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IncreaseCTxt : MonoBehaviour
{
	int currentExpressed = 0;
	public float lerpSpd;
	public TextMeshProUGUI txt;
	private void Awake()
	{
		txt = GetComponent<TextMeshProUGUI>();
		currentExpressed = int.Parse(txt.text);
	}
	private void Update()
	{
		if (currentExpressed < ScoreManager.Score)
		{
			currentExpressed = Mathf.CeilToInt(Mathf.Lerp(currentExpressed, ScoreManager.Score, currentExpressed / (ScoreManager.Score * lerpSpd * 10000) + 0.01f));
			txt.text = currentExpressed.ToString();
		}
		else if (currentExpressed > ScoreManager.Score)
		{

			currentExpressed = Mathf.FloorToInt(Mathf.Lerp(currentExpressed, ScoreManager.Score, ScoreManager.Score / (currentExpressed * lerpSpd * 10000) + 0.01f));
			txt.text = currentExpressed.ToString();
		}
	}
}
