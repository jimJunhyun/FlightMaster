using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardFollow : MonoBehaviour
{
    Vector3 initPos = new Vector3();
	public Transform target;
	private void Awake()
	{
		initPos = transform.position;
	}
	// Update is called once per frame
	void LateUpdate()
    {
        transform.position = target.position + initPos;
    }
}
