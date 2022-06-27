using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{

    public static LevelManager Instance;

	public int waveEnemyNumBase;
	public float waveGap;

	public UnityEvent restarter;
	[HideInInspector]
	public float waveMultiplier;

	[Header("수정해도 의미없음")]
    public int currentWave;
    public int waveEnemyNum;

	private void Awake()
	{
		Debug.Log("AWAKELM");
		Instance = this;
		if(SaveManager.Load() != null)
		{
			currentWave = SaveManager.Load(1);
		}
		else
		{
			currentWave = 0;
		}
		
		NextWave();
	}

	public void RestartWave()
	{
		Time.timeScale = 1;
		waveMultiplier = 1 + Mathf.Log10(Mathf.Sqrt(Mathf.Pow(currentWave, 3f)));
		waveEnemyNum = (int)(waveEnemyNumBase * waveMultiplier);
		restarter.Invoke();
	}

	public void NextWave()
	{
		++currentWave;
		waveMultiplier = 1 + Mathf.Log10(Mathf.Sqrt(Mathf.Pow(currentWave, 3f)));
		waveEnemyNum = (int)(waveEnemyNumBase * waveMultiplier);
	}

	public void ResetWave()
	{
		currentWave = SaveManager.Load(1);
	}
}
