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
		transform.position = Vector3.zero;
		transform.rotation = Quaternion.identity;
		poolParent.ReturnPool(this);
	}

}
