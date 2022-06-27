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
	public int score;
	int initScore;
	int initMaxHp;
	int currentHp;
	public UnityEvent OnHit;
	public PoolObject myPool;
	public ParticleSystem DestParticle;

	GoldObj myGold;
	


	private void Awake()
	{
		myGold = GetComponent<GoldObj>();
		initMaxHp = MaxHp;
		initScore = score;
		currentHp = MaxHp;
		StartCoroutine(DelayDest());
	}
	private void OnEnable()
	{
		MaxHp = (int)(initMaxHp * LevelManager.Instance.waveMultiplier);
		score = Mathf.RoundToInt( initScore * LevelManager.Instance.waveMultiplier);
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
		ScoreManager.Score -= score;
		myPool.Returner();
	}

	private void LateUpdate()
	{
		if(currentHp <= 0)
		{
			--LevelManager.Instance.waveEnemyNum;
			ScoreManager.Score += score;
			Instantiate(DestParticle, transform.position, DestParticle.transform.rotation);
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
		ScoreManager.Score -= score;
		myPool.Returner();
	}
}
