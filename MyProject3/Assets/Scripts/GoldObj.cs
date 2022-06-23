using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldObj : MonoBehaviour
{
	public int Gold;
	public void GoldAdd()
	{
		GoldCtrl.GoldAmount += (int)(Gold * LevelManager.Instance.waveMultiplier);
	}
}
