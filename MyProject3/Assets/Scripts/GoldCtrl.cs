using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoldCtrl : MonoBehaviour
{
	public UnityEvent OnValueChanged;

	public static int GoldAmount;
	int prevGold;
	private void Awake()
	{
		prevGold = GoldAmount;
	}
	public void Update()
	{
		if(prevGold != GoldAmount)
		{
			prevGold = GoldAmount;
			OnValueChanged.Invoke();
		}
	}
}
