using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCrystalCtrl : MonoBehaviour
{
    public Transform target;
	public ParticleSystem Shard;
	public List<Transform> crystals = new List<Transform>();

	List<MeshRenderer> cryRenderers = new List<MeshRenderer>();
	Vector3 initPos = new Vector3();
	private void Awake()
	{
		initPos = transform.position;
		foreach (var item in crystals)
		{
			cryRenderers.Add(item.GetComponentInChildren<MeshRenderer>());
			item.GetComponentInChildren<MeshRenderer>().enabled = false;
		}
	}

	public void Damaged()
	{
		StartCoroutine(delayOff());
		Transform broken = crystals.Find(x => x.gameObject.activeSelf);
		Instantiate(Shard, broken.position, Shard.transform.rotation);
		broken.gameObject.SetActive(false);
	}

	IEnumerator delayOff()
	{
		foreach (var item in cryRenderers)
		{
			item.enabled = true;
		}
		yield return new WaitForSeconds(1f);
		foreach (var item in cryRenderers)
		{
			item.enabled = false;
		}
	}

	// Update is called once per frame
	void LateUpdate()
    {
        transform.position = target.position + initPos;
    }
}
