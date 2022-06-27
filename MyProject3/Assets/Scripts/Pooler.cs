using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    public List<PoolObject> poolObj = new List<PoolObject>();
	public int poolAmount;
    List<PoolObject> poolObjs = new List<PoolObject>();
	public bool isRandom = false;
	private void Awake()
	{
		for (int i = 0; i < poolAmount; i++)
		{
			PoolObject pooled = Instantiate(poolObj[Random.Range(0, poolObj.Count)], Vector3.zero, Quaternion.identity, transform);
			poolObjs.Add(pooled);
			pooled.gameObject.SetActive(false);

		}
	}

	public GameObject UsePool()
	{
		
		GameObject g ;
		if (isRandom)
		{
			List<PoolObject> gs = poolObjs.FindAll((x)=> !x.gameObject.activeSelf);
			g = gs[Random.Range(0, gs.Count)].gameObject;
		}
		else
		{
			g= poolObjs.Find((x) => {
				return !x.gameObject.activeSelf;
			}).gameObject;
		}
		
		g.SetActive(true);
		return g;
	}
	public void ReturnPool(PoolObject obj)
	{
		obj.gameObject.SetActive(false);
	}

	public void ReturnAll()
	{
		foreach (var item in poolObjs)
		{
			item.Returner();
		}
	}
}
