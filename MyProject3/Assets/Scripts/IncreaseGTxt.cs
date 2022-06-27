using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IncreaseGTxt : MonoBehaviour
{
    int currentExpressed = 0;
	public float lerpSpd;
	public TextMeshProUGUI txt;
	private void Awake()
	{ 
		txt = GetComponent<TextMeshProUGUI>();
		currentExpressed = int.Parse(txt.text.Remove(0, 1));
	}
	private void Update()
	{
		if(currentExpressed < GoldCtrl.GoldAmount) //µ· È¹µæ
		{
			currentExpressed = Mathf.CeilToInt(Mathf.Lerp(currentExpressed, GoldCtrl.GoldAmount, currentExpressed / (GoldCtrl.GoldAmount * lerpSpd * 10000)  + 0.01f));
			txt.text = $"${currentExpressed}";
		}
		else if(currentExpressed > GoldCtrl.GoldAmount) //µ· ¼Òºñ
		{
			
			currentExpressed = Mathf.FloorToInt(Mathf.Lerp(currentExpressed, GoldCtrl.GoldAmount, GoldCtrl.GoldAmount / ( currentExpressed * lerpSpd * 10000) + 0.01f));
			txt.text = $"${currentExpressed}";
		}
	}
}
