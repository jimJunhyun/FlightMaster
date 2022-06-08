using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyGenManager : MonoBehaviour
{
    public EnemyGenerator Generator;
    public float genGap = 1f;
    public float genPosRad;
    public int genMax = 10;
    List<EnemyGenerator> geners = new List<EnemyGenerator>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Make());
    }


	IEnumerator Make()
	{
		while (true)
		{
            yield return null;
            if(geners.Count < genMax)
			{
                yield return genGap;
                Vector3 place = Random.insideUnitSphere * genPosRad;
                EnemyGenerator e = Instantiate(Generator, place, Quaternion.identity, transform);
                e.Init();
                geners.Add(e);
            }
            
		}
	}



}
