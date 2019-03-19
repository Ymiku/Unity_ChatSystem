using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionButton : MonoBehaviour {
	public Text text;
	public void SetText(string s)
	{
		text.text = s;
	}
}
