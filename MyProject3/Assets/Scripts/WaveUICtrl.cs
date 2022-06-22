using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveUICtrl : MonoBehaviour
{
    public List<Sprite> numbers = new List<Sprite>();
    public List<Image> waveTexts = new List<Image>();
	public Image WText;
    int prevWave = 0;
	int textVal;
	public float onOffTime = 1f;
	string expressedNum;
	private void Awake()
	{
		GetComponentsInChildren(waveTexts);
		StartCoroutine(OnOff());
	}
	private void Update()
	{
		if(prevWave != LevelManager.Instance.currentWave)
		{
			prevWave = LevelManager.Instance.currentWave;
			expressedNum = prevWave.ToString();
			foreach (var item in waveTexts)
			{
				item.sprite = numbers[10];
			}
			StartCoroutine(OnOff());
			for (int i = 0; i < expressedNum.Length; i++)
			{
				if(int.TryParse(expressedNum[i].ToString(), out textVal))
					waveTexts[i].sprite = numbers[textVal];
			}

		}
	}

	IEnumerator OnOff()
	{
		foreach (var item in waveTexts)
		{
			item.enabled = true;
		}
		WText.enabled = true;
		yield return new WaitForSeconds(onOffTime);
		foreach (var item in waveTexts)
		{
			item.enabled = false;

		}
		WText.enabled = false;
	}
}
