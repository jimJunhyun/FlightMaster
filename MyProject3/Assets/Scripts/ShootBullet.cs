using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
	[Tooltip("坷弗率 = 1, 哭率 = 0, 啊款单(荣) = 2")]
	public int side;
	public float aimDist = 50f;
    public BulletFly bullet;
	public float gap = 0.1f;
	Vector3 direction;
	PlaneCtrl myPlane;
	

	private void Start()
	{
		direction = new Vector3(0,0, aimDist);
		myPlane = transform.GetComponentInParent<PlaneCtrl>();
		StartCoroutine(DelayShootAuto(gap));
	}

	private void Update()
	{
		if (Input.GetMouseButton(side))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			direction = ray.origin + (ray.direction * aimDist);
		}
		if (Input.GetMouseButtonUp(side))
		{
			direction = new Vector3(0,0, aimDist);
		}
	}
	private void LateUpdate()
	{
		transform.LookAt(direction);
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
