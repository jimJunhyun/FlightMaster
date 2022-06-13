using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
	public float destroyTimer = 3f;
    public float speed = 2000f;
    public Rigidbody myRig;
	public int damage;
	PoolObject myPool;
	public void Awake()
	{
		myPool = GetComponent<PoolObject>();
		StartCoroutine(DelayReturn(destroyTimer));
	}
	private void OnEnable()
	{
		StartCoroutine(DelayReturn(destroyTimer));
	}
	public void Fire(Vector3 dir, int dam)
	{
		transform.rotation = Quaternion.LookRotation(dir);
		myRig.AddForce(dir * speed, ForceMode.Impulse);
		damage = dam;
	}
	IEnumerator DelayReturn(float time)
	{
		yield return new WaitForSeconds(time);
		myPool.Returner();
	}
}
