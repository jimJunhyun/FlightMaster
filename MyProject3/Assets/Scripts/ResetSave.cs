using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSave : MonoBehaviour
{
	private void Awake()
	{
		PlayerPrefs.DeleteAll();
	}
}
