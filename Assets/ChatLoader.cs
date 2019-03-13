using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeEditorFramework;
public class ChatLoader : MonoBehaviour {
	public NodeCanvas canvas;
	// Use this for initialization
	void Start () {
		uint m = 1;
		for (int i = 0; i < 32; i++) {
			m<<=1;
			Debug.Log (m);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
