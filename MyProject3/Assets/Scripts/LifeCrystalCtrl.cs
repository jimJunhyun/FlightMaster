using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCrystalCtrl : MonoBehaviour
{
	public ParticleSystem Shard;
	public List<Transform> crystals = new List<Transform>();

	List<MeshRenderer> cryRenderers = new List<MeshRenderer>();
	private void Awake()
	{
		if(SaveManager.Load() != null)
		{
			SetCryNum(SaveManager.Load(7));
		}
		foreach (var item in crystals)
		{
			cryRenderers.Add(item.GetComponentInChildren<MeshRenderer>());
			item.GetComponentInChildren<MeshRenderer>().enabled = false;
		}
	}

	void SetCryNum(int cnt)
	{
		cnt = Mathf.Clamp(cnt, 1, 3);
		for (int i = 0; i < crystals.Count; i++)
		{
			if(cnt > 0)
			{
				crystals[i].gameObject.SetActive(true);
				--cnt;
			}
			else
			{
				crystals[i].gameObject.SetActive(false);
			}
			
		}
	}

	public void Damaged()
	{
		StartCoroutine(delayOff());
		Transform broken = crystals.Find(x => x.gameObject.activeSelf);
		Instantiate(Shard, broken.position, Shard.transform.rotation);
		broken.gameObject.SetActive(false);
	}

	public void Recovery()
	{
		List<Transform> brokens =  crystals.FindAll((x) => !x.gameObject.activeSelf);
		for (int i = 0; i < brokens.Count; i++)
		{
			brokens[i].gameObject.SetActive(true);
		}
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
}
