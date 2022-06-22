using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldObj : MonoBehaviour
{
	public int Gold;
	private void OnDisable()
	{
		GoldCtrl.GoldAmount += (int)(Gold * LevelManager.Instance.waveMultiplier);
	}
}
