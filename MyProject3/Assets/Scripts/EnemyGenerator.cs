using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
	float gap = 3f;
	Enemy enemy;

	public void Init()
	{
		enemy = Resources.Load<Enemy>("Enemy");
		StartCoroutine(FactoryActive());
	}

    public IEnumerator FactoryActive()
	{
		while (true)
		{
			yield return new WaitForSeconds(gap);
			Enemy e = Instantiate(enemy, transform.position, transform.rotation);
			e.Init();
		}
	}
}
