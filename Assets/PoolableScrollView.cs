using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PoolableScrollView : MonoBehaviour {
	public NodeItemProxy[] prefabs;
	Stack<NodeItemProxy>[] _pools;
	#if UNITY_EDITOR
	[SerializeField]
	#endif
	List<NodeItemProxy> _activeItems = new List<NodeItemProxy>();
	RectTransform viewPortTrans;
	RectTransform contextTrans;
	// Use this for initialization
	void Start()
	{
		Init ();
	}
	void Init () {
		viewPortTrans = GetComponent<ScrollRect> ().viewport;
		contextTrans = GetComponent<ScrollRect> ().content;
		//_activeItems.Clear ();
		_pools = new Stack<NodeItemProxy>[prefabs.Length];
		for (int i = 0; i < _pools.Length; i++) {
			_pools [i] = new Stack<NodeItemProxy> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		while (CheckBorder()) {}
	}
	bool CheckBorder()
	{
		if (_activeItems.Count == 0)
			return false;
		if (NeedCull (_activeItems [0])) {
			PoolUp (_activeItems [0]);
			return true;
		}
		if (NeedCull (_activeItems [_activeItems.Count-1])) {
			PoolDown (_activeItems [_activeItems.Count-1]);
			return true;
		}
		return false;
	}
	bool TryAddDown()
	{
		return false;
	}
	bool TryAddUp ()
	{
		return false;
	}
	void PoolUp(NodeItemProxy node)
	{
		Pool (node);
		float nodeHeight = node.height;
		//contextTrans.sizeDelta = new Vector2 (contextTrans.sizeDelta.x,contextTrans.sizeDelta.y-nodeHeight);

		for (int i = 0; i < _activeItems.Count; i++) {
			//_activeItems [i].cachedRectTransform.anchoredPosition = new Vector2 (_activeItems [i].cachedRectTransform.anchoredPosition.x,_activeItems [i].cachedRectTransform.anchoredPosition.y+nodeHeight);
		}
		//contextTrans.anchoredPosition = new Vector2 (contextTrans.anchoredPosition.x,contextTrans.anchoredPosition.y-nodeHeight);
	}
	void PoolDown(NodeItemProxy node)
	{
		Pool (node);
		contextTrans.sizeDelta = new Vector2 (contextTrans.sizeDelta.x,contextTrans.sizeDelta.y-node.height);
	}
	void Pool(NodeItemProxy node)
	{
		_activeItems.Remove (node);
		node.gameObject.SetActive (false);
	}
	bool NeedCull(NodeItemProxy node)
	{
		if(_activeItems.IndexOf(node)==0)
		Debug.Log ((node.pos.y - node.height).ToString());
		if (node.pos.y - node.height + contextTrans.anchoredPosition.y > 0)
			return true;
		if (node.pos.y + contextTrans.anchoredPosition.y < -viewPortTrans.sizeDelta.y)
			return true;
		return false;
	}
}
