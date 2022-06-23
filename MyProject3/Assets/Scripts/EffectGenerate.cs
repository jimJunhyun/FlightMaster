using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectGenerate : MonoBehaviour
{
    public ParticleSystem goldGather;
    ParticleSystem currentEff;
    public void Generate()
	{
        if(currentEff == null)
		{
            currentEff = Instantiate(goldGather, transform.position, goldGather.transform.rotation);
        }
        
	}
}
