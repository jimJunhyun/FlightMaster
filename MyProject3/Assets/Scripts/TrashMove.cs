using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrashMove : MonoBehaviour
{

    public float rotSpeed;
    public float moveSpeed;
	public float destGap;
	public int MaxHp;
	int initMaxHp;
	int currentHp;
	public UnityEvent OnHit;
	public PoolObject myPool;

	GoldObj myGold;


	private void Awake()
	{
		
		myGold = GetComponent<GoldObj>();
		initMaxHp = MaxHp;
		currentHp = MaxHp;
		StartCoroutine(DelayDest());
	}
	private void OnEnable()
	{
		MaxHp = (int)(initMaxHp * LevelManager.Instance.waveMultiplier);
		currentHp = MaxHp;
		StartCoroutine(DelayDest());
	}

	private void Update()
	{
		transform.Rotate(transform.up, rotSpeed * Time.deltaTime);
		transform.Translate(moveSpeed * Vector3.back * Time.deltaTime, Space.World);
	}

	IEnumerator DelayDest()
	{
		yield return new WaitForSeconds(destGap);
		--LevelManager.Instance.waveEnemyNum;
		myPool.Returner();
	}

	private void LateUpdate()
	{
		if(currentHp <= 0)
		{
			--LevelManager.Instance.waveEnemyNum;
			myGold.GoldAdd();
			myPool.Returner();
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.layer == 7)
		{
			currentHp -= collision.gameObject.GetComponent<BulletFly>().damage;
		}
	}

	private void OnBecameInvisible()
	{
		--LevelManager.Instance.waveEnemyNum;
		myPool.Returner();
	}
}
