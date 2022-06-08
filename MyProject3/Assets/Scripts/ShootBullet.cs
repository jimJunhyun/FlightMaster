using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public BulletFly bullet;
	public float gap = 0.1f;
	PlaneCtrl myPlane;

	private void Start()
	{
		myPlane = transform.GetComponentInParent<PlaneCtrl>();
		StartCoroutine(DelayShootAuto(gap));
	}

	IEnumerator DelayShootAuto(float gap)
	{
		while (true)
		{
			yield return null;
			if (!myPlane.IsDashing)
			{
				yield return new WaitForSeconds(gap);
				BulletFly b = Instantiate(bullet, transform.position, Quaternion.identity);
				b.Fire(transform.forward);
			}
			
		}
		
	}
}
