using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoldCtrl : MonoBehaviour
{
	public UnityEvent OnValueChanged;

	public static int GoldAmount;
	int prevGold;

	AudioSource mySound;
	private void Awake()
	{
		
		if(SaveManager.Load() != null)
		{
			GoldAmount = SaveManager.Load(0);
		}
		else
		{
			GoldAmount = 0;
		}
		mySound = GetComponent<AudioSource>();
		prevGold = GoldAmount;
	}
	public void Update()
	{
		if(prevGold != GoldAmount)
		{
			if(!mySound.isPlaying)
				mySound.Play();
			prevGold = GoldAmount;
			OnValueChanged.Invoke();
		}
	}

	public void ResetGold()
	{
		GoldAmount =  SaveManager.Load(0);
	}
}
