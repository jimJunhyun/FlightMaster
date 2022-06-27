using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDisabler : MonoBehaviour
{
    public List<Button> buttons;
	public void Disabler(int index)
	{
		buttons[index].interactable = false;
	}
}
