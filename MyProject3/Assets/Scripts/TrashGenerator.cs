using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashGenerator : MonoBehaviour
{
    public List<TrashMove> trashes = new List<TrashMove>();
    public float genGap = 1f;
	public float genDist = 60f;
    public Vector4 genZone;
	public Transform player;

	TrashMove trash;
	

	private void Start()
	{
		StartCoroutine(Generate());
	}

	IEnumerator Generate()
	{
		while (true)
		{
			yield return new WaitForSeconds(genGap);
			transform.position = new Vector3(Random.Range(genZone.x, genZone.z), Random.Range(genZone.y, genZone.w), player.position.z + genDist);
			transform.eulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
			trash = trashes[Random.Range(0, trashes.Count)];
			Instantiate(trash, transform.position, transform.rotation);
		}
	}
}
