using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
	[Tooltip("坷弗率 = 1, 哭率 = 0, 啊款单(荣) = 2")]
	public int side;
	public float aimDist = 50f;
    public BulletFly bullet;
	public float gap = 0.5f;
	public int damage;
	public Pooler pooler;

	AudioSource mySound;
	Vector3 direction;
	PlaneCtrl myPlane;
	Ray ray;
	Vector2 mousePosBuffer;

	private void Start()
	{
		mySound = GetComponent<AudioSource>();
		mousePosBuffer = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
		direction = new Vector3(0,0, aimDist);
		myPlane = transform.GetComponentInParent<PlaneCtrl>();
		StartCoroutine(DelayShootAuto(gap));
	}

	private void Update()
	{
		if (Input.GetMouseButton(side) && Time.timeScale == 1)
		{
			mousePosBuffer = Input.mousePosition;

		}
		ray = Camera.main.ScreenPointToRay(mousePosBuffer);
		direction = ray.origin + (ray.direction * aimDist);
		damage = ShopperButtons.Instance.Buttons[0].Level * 5 + 10;
		gap = 0.5f - (ShopperButtons.Instance.Buttons[2].Level * 0.05f);
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
			mySound.Play();
			GameObject bullet = pooler.UsePool();
			bullet.transform.position = transform.position;
			bullet.GetComponent<BulletFly>().Fire(transform.forward, damage);
		}
		
	}
}
