using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
	public List<Sprite> ThreeToZero = new List<Sprite>();
	public Image delayText;
    Image shopPanel;
	Coroutine delayer;
	
	bool isShopping;
	private void Start()
	{
		shopPanel = GetComponentInChildren<Image>();
		shopPanel.gameObject.SetActive (false);
		delayText.enabled = false;
		isShopping = false;
	}
	// Update is called once per frame
	void Update()
    {
		if (Input.GetKeyDown(KeyCode.E) && !isShopping)
		{
			isShopping = true;
			delayText.enabled = false;
			shopPanel.gameObject.SetActive(true);
			if(delayer != null)
				StopCoroutine(delayer);
			Time.timeScale = 0;
		}
		else if(Input.GetKeyDown(KeyCode.E) && isShopping)
		{
			isShopping  =false;
			shopPanel.gameObject.SetActive(false);
			delayer = StartCoroutine(DelayRestart());
		}
    }

	IEnumerator DelayRestart()
	{
		delayText.enabled = true;
		for (int i = 0; i <= 3; i++)
		{
			delayText.sprite = ThreeToZero[i];
			yield return new WaitForSecondsRealtime(1f);
		}
		delayText.sprite = ThreeToZero[0];
		delayText.enabled = false;
		Time.timeScale = 1f;
	}
}
