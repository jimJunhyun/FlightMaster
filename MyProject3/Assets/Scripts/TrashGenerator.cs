using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashGenerator : MonoBehaviour
{
    public float genGap = 1f;
	public float genDist = 60f;
    public Vector4 genZone;
	public Transform player;
	public Pooler pool;

	int genCount;

	private void Start()
	{
		StartCoroutine(Generate());
	}

	IEnumerator Generate()
	{
		genCount = LevelManager.Instance.waveEnemyNum;
		while (true)
		{
			yield return new WaitForSeconds(genGap);
			
			if(genCount > 0)
			{
				--genCount;
				GameObject trash = pool.UsePool();
				transform.position = new Vector3(Random.Range(genZone.x, genZone.z), Random.Range(genZone.y, genZone.w), player.position.z + genDist);
				transform.eulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
				trash.transform.position = transform.position;
				trash.transform.rotation = transform.rotation;
			}
			
			if(LevelManager.Instance.waveEnemyNum <= 0)
			{
				break;
			}
		}
		
		yield return new WaitForSeconds(LevelManager.Instance.waveGap);
		LevelManager.Instance.NextWave();
		yield return Generate();
	}
}
