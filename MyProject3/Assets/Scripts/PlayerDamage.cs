using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDamage : MonoBehaviour
{
    public int Heart;
    int currentHeart;

	public UnityEvent OnDamaged;
	public UnityEvent OnDead;

	private void Awake()
	{
		currentHeart = Heart;
	}
	// Update is called once per frame
	void Update()
    {
        if(currentHeart <= 0)
		{
			OnDead.Invoke();
		}
    }
	public void Damage()
	{
		--currentHeart;
		OnDamaged.Invoke();
	}
}
