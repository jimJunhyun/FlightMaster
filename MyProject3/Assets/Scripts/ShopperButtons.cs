using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ShopperButtons : MonoBehaviour
{

	public static ShopperButtons Instance;

	ButtonDisabler disabler;
	public struct ShopButtons
	{
		public int Level{ get; set;}
		public int MaxLevel{ get; set;}
		public int CostMult { get; set;}
		public int Cost{ get => (100 +Mathf.CeilToInt(Mathf.Pow(Level, 2))) * CostMult;}
		public UnityEvent OnLevelUp;
	}

	public List<UnityEvent> LevelUps = new List<UnityEvent>();
	public List<TextMeshProUGUI> CostTxts  = new List<TextMeshProUGUI>();

	[HideInInspector]
	public List<ShopButtons> Buttons = new List<ShopButtons>();
	// 0, 1
	// 2, 3

	private void Awake()
	{
		Instance = this;
		disabler = GetComponent<ButtonDisabler>();
		for (int i = 0; i <= 3; ++i)
		{
			
			ShopButtons b = new ShopButtons();
			b.CostMult = 1;
			b.MaxLevel = -1;
			b.CostMult = 1;
			b.OnLevelUp = LevelUps[i];
			if (i == 2)
			{
				b.CostMult = 3;
				b.MaxLevel = 6;
			}
			if (SaveManager.Load() != null)
			{
				b.Level = SaveManager.Load(3+i);
				
			}
			else
			{
				b.Level = 1;
			}
			
			Buttons.Add(b);
			CostTxts[i].text = $"Cost : {Buttons[i].Cost}";
		}
		for (int i = 0; i < Buttons.Count; i++)
		{
			if (Buttons[i].MaxLevel != -1 && Buttons[i].Level >= Buttons[i].MaxLevel)
			{

				disabler.Disabler(i);
			}
		}
		Debug.Log("AWAKESHOP");
	}

	void Gamble(int amount)
	{
		if(Random.Range(0,2) == 0)
		{
			GoldCtrl.GoldAmount += amount * 2;
		}
		else
		{

		}
	}

	public void DoGamble()
	{
		Gamble(Buttons[3].Cost);
	}

	public void ChangeLevel(int index)
	{
		if((Buttons[index].MaxLevel == -1 || Buttons[index].Level < Buttons[index].MaxLevel) && GoldCtrl.GoldAmount >= Buttons[index].Cost)
		{
			ShopButtons b = Buttons[index];
			GoldCtrl.GoldAmount -= Buttons[index].Cost;
			Buttons[index].OnLevelUp.Invoke();
			b.Level += 1;
			Buttons[index] = b;
			CostTxts[index].text = $"Cost : {Buttons[index].Cost}";
			if (Buttons[index].MaxLevel != -1 && Buttons[index].Level >= Buttons[index].MaxLevel)
			{
				disabler.Disabler(index);
			}
		}
		
	}

	public void ResetLevels()
	{
		for (int i = 0; i < Buttons.Count; i++)
		{
			ShopButtons b = Buttons[i];
			b.Level = SaveManager.Load(3 + i);
			
			Buttons[i] = b;
		}
	}
}
