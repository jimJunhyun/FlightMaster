using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDamage : MonoBehaviour
{
	public static PlayerDamage Instance;
    public int Heart;
    int currentHeart;
	bool isImmune;

	public UnityEvent<int> OnDamaged;

	private void Awake()
	{
		
		Instance = this;
		if (SaveManager.Load() != null)
		{
			currentHeart = SaveManager.Load(7);
		}
		else
		{
			currentHeart = Heart;
		}
		
	}
	
	void Update()
    {
        if(currentHeart <= 0)
		{
			Time.timeScale = 0;
			LevelManager.Instance.RestartWave();
		}
    }

	public void Heal()
	{
		currentHeart = Heart;
	}

	public void ResetHeart()
	{
		currentHeart = SaveManager.Load(7);
	}

	public void Damage()
	{
		if (!isImmune)
		{
			--currentHeart;
			Invoker();
		}
	}
	public void Immune(float time)
	{
		StartCoroutine(ImmuneCount(time));
	}
	IEnumerator ImmuneCount(float time)
	{
		isImmune = true;
		yield return new WaitForSeconds(time);
		isImmune = false;
	}
	void Invoker()
	{
		OnDamaged.Invoke(currentHeart);
		Immune(1f);
	}
}
