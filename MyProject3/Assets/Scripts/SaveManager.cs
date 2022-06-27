using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
	private void Awake()
	{
		StartCoroutine(AutoSaver());
	}

	IEnumerator AutoSaver()
	{
		while (true)
		{
			yield return new WaitForSecondsRealtime(10f);
			Save();
			Debug.Log("Saved");
		}
	}

	public static void Save()
	{
		
		PlayerPrefs.SetString
			("SaveData", GoldCtrl.GoldAmount + 
			" " + LevelManager.Instance.currentWave +
			" " + ScoreManager.Score +
			" " + ShopperButtons.Instance.Buttons[0].Level +
			" " + ShopperButtons.Instance.Buttons[1].Level +
			" " + ShopperButtons.Instance.Buttons[2].Level +
			" " + ShopperButtons.Instance.Buttons[3].Level +
			" " + PlayerDamage.Instance.Heart);
	}
	public static List<int> Load()
	{
		string[] datas = PlayerPrefs.GetString("SaveData", "").Split(' ');
		if(datas.Length != 1)
		{
			List<int> validDatas = new List<int>();
			foreach (var item in datas)
			{
				validDatas.Add(int.Parse(item));
			}
			return validDatas;
		}
		else
		{
			return null;
		}
	}
	public static int Load(int index)
	{
		string[] datas = PlayerPrefs.GetString("SaveData", null).Split(' ');
		List<int> validDatas = new List<int>();
		foreach (var item in datas)
		{
			validDatas.Add(int.Parse(item));
		}
		return validDatas[index];
	}
}
