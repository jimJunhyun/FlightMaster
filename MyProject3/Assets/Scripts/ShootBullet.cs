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
	public int damage;
	public Pooler pooler;
	Vector3 direction;
	PlaneCtrl myPlane;
	Ray ray;
	Vector2 mousePosBuffer;

	private void Start()
	{
		mousePosBuffer = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
		direction = new Vector3(0,0, aimDist);
		myPlane = transform.GetComponentInParent<PlaneCtrl>();
		StartCoroutine(DelayShootAuto(gap));
	}

	private void Update()
	{
		if (Input.GetMouseButton(side))
		{
			mousePosBuffer = Input.mousePosition;
			
		}
		ray = Camera.main.ScreenPointToRay(mousePosBuffer);
		direction = ray.origin + (ray.direction * aimDist);
	}
	private void LateUpdate()
	{
		transform.LookAt(direction);
	}

	IEnumerator DelayShootAuto(float gap)
	{
		while (true)
		{
			yield return new WaitForSeconds(gap);
			GameObject bullet = pooler.UsePool();
			bullet.transform.position = transform.position;
			bullet.GetComponent<BulletFly>().Fire(transform.forward, damage);
		}
		
	}
}
