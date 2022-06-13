using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    public PoolObject poolObj;
	public int poolAmount;
    List<PoolObject> poolObjs = new List<PoolObject>();
	private void Awake()
	{
		for (int i = 0; i < poolAmount; i++)
		{
			PoolObject pooled = Instantiate(poolObj, Vector3.zero, Quaternion.identity, transform);
			poolObjs.Add(pooled);
			pooled.gameObject.SetActive(false);
			
		}
	}

	public GameObject UsePool()
	{
		GameObject g = poolObjs.Find((x) => { return !x.gameObject.activeSelf; }).gameObject;
		g.SetActive(true);
		return g;
	}
	public void ReturnPool(PoolObject obj)
	{
		obj.gameObject.SetActive(false);
	}
}
