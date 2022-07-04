using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpOnOff : MonoBehaviour
{
	public Image HelpPanel;
	private void Awake()
	{
		HelpPanel.gameObject.SetActive(false);
	}
	public void OnPanel()
	{
		HelpPanel.gameObject.SetActive(true);
	}
	public void OffPanel()
	{
		HelpPanel.gameObject.SetActive(false);
	}
}
