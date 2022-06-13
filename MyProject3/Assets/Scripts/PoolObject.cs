using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    Pooler poolParent;
	private void Awake()
	{
		poolParent = GetComponentInParent<Pooler>();
	}
	public void Returner()
	{
		Debug.Log("dsfa");
		poolParent.ReturnPool(this);
	}

}
