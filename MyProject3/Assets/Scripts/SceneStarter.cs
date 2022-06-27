using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStarter : MonoBehaviour
{
    public void Change()
	{
		SceneManager.LoadScene(1);
	}
}
