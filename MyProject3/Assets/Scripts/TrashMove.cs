using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrashMove : MonoBehaviour
{
    public float rotSpeed;
    public float moveSpeed;
	public float distGap;
	public int MaxHp;
	int currentHp;
	UnityEvent OnHit;

	private void Awake()
	{
		currentHp = MaxHp;
		Destroy(gameObject, distGap);
	}

	private void Update()
	{
		transform.Rotate(transform.up, rotSpeed * Time.deltaTime);
		transform.Translate(moveSpeed * Vector3.back * Time.deltaTime, Space.World);
	}

	private void LateUpdate()
	{
		if(currentHp <= 0)
		{
			Destroy(gameObject);
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
		Destroy(gameObject);
	}
}
