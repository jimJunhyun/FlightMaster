using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager Instance;

	public int waveEnemyNumBase;
	public float waveGap;
	[HideInInspector]
	public float waveMultiplier;

	[Header("수정해도 의미없음")]
    public int currentWave;
    public int waveEnemyNum;

	private void Awake()
	{
		Instance = this;
		currentWave = 0;
		NextWave();
	}


	public void NextWave()
	{
		++currentWave;
		waveMultiplier = 1 + Mathf.Log10(Mathf.Sqrt(Mathf.Pow(currentWave, 3f)));
		waveEnemyNum = (int)(waveEnemyNumBase * waveMultiplier);
	}
}
