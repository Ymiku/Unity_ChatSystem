using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class qweqwe : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<ScrollRect> ().content.anchoredPosition+=Vector2.up;
	}
}
