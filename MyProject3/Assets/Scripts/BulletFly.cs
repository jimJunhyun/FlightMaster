using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
	public float DestroyTimer = 7f;
    public float speed = 2000f;
    public Rigidbody myRig;
	public void Awake()
	{
		Destroy(gameObject, DestroyTimer);
	}
	public void Fire(Vector3 dir)
	{
		transform.rotation = Quaternion.LookRotation(dir);
		myRig.AddForce(dir * speed, ForceMode.Impulse);
	}
}
