using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Standard;
using UnityEngine.UI;
public class NodeItemProxy : MonoBehaviour {
	public int padding = 20;
	public int prefabId;
	public Vector2 pos{
		get
		{
			return cachedRectTransform.anchoredPosition;
		}	
	}
	public float width{
		get
		{ 
			return cachedRectTransform.sizeDelta.x;
		}
	}
	public float height{
		get
		{ 
			return cachedRectTransform.sizeDelta.y;
		}
	}
	RectTransform _cachedRectTransform;
	public RectTransform cachedRectTransform{
		get{
			if (_cachedRectTransform == null) {
				_cachedRectTransform = GetComponent<RectTransform> ();
			}
			return _cachedRectTransform;
		}
	}
	public Node linkedNode;
	public float SetData(Node node)
	{
		linkedNode = node;
		return 20.0f;
	}
}
