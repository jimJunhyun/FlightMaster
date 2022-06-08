using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	enum EnemyType
	{
        None = -1,
        Floating,
        Following,
        Attacking,

        Max
	}
    int myType;
    float speed;
    Vector3 dir;
    Transform target;

    public void Init()
	{
        myType = UnityEngine.Random.Range(0, (int)EnemyType.Max);
        target = GameObject.Find("Jet").transform;
        if(myType == ((int)EnemyType.Floating))
            speed = 3f;
        else if(myType == ((int)EnemyType.Following))
            speed = 6f;
        else if(myType == ((int)EnemyType.Attacking))
            speed = 12f;
	}
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
	{
        if(myType == ((int)EnemyType.Floating))
		{
            dir = UnityEngine.Random.insideUnitSphere;
		}
        else /*if (myType != ((int)EnemyType.Floating))*/
		{
            dir = (target.position - transform.position).normalized;
		}
        transform.Translate(dir * speed * Time.deltaTime);

	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.gameObject.layer == 7)
		{
            Debug.Log("ИэСп");
            Destroy(collision.gameObject);
            Destroy(gameObject);
		}
	}
}
