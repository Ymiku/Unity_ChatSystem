using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Standard;
public class ChatManager : Singleton<ChatManager> {
	public delegate void RefreshEventHandler(List<ChatInstance> chatLst);
	public event RefreshEventHandler OnRefresh;
	//name name selectionID
	string curName = "";
	ChatInstance curInstance;
	public Dictionary<string,int> name2Id = new Dictionary<string, int> {
		{ "Tom",0 },
		{ "Jenny",1 },
	};
	public Dictionary<string,int> id2Name = new Dictionary<string, int>();
	Dictionary<int,ChatInstance> pairId2Instance = new Dictionary<int, ChatInstance>();
	List<ChatInstance> orderedInstance = new List<ChatInstance>();
	//
	public Node MoveUp()
	{
		return curInstance.GetFront ();
	}
	public Node MoveDown()
	{
		return curInstance.GetNext ();
	}
	public void PoolUp()
	{
		curInstance.PoolUp ();
	}
	public void PoolDown()
	{
		curInstance.PoolDown ();
	}
	public void EnterChat(string name1,string name2)
	{
		curInstance.OnExit ();
		curInstance = pairId2Instance [GetPairID(name1,name2)];
		curInstance.OnEnter ();
	}
	public Node TryGetOptionNode()//get every tick
	{
		if (curInstance.curRunningNode is ChatOptionNode) {
			return curInstance.curRunningNode;
		}
		return null;
	}
	public void Refresh()//when new node enter
	{
		orderedInstance.Clear ();
		foreach (var item in pairId2Instance.Values) {
			if (orderedInstance.Count == 0) {
				orderedInstance.Add (item);
				continue;
			}
			long t = item.lastChatTimeStamp;
			for (int i = 0; i < orderedInstance.Count; i++) {
				if (t > orderedInstance [i].lastChatTimeStamp) {
					orderedInstance.Insert (i, item);
					continue;
				}
			}
			orderedInstance.Add (item);
		}
		OnRefresh (orderedInstance);
	}
	//
	public void OnEnter(string name)
	{
		id2Name.Clear ();
		foreach (var item in name2Id.Keys) {
			id2Name.Add (name2Id[item],item);
		}
		pairId2Instance.Clear ();
		List<string> friends = XMLSaver.saveData.GetFriendsLst ();
		for (int i = 0; i < friends.Count; i++) {
			string otherName = friends[i];
			int id = GetPairID (curName,friends[i]);
			ChatInstance instance = new ChatInstance ();
			instance.OnInit (name,otherName,id);
			pairId2Instance.Add (id,instance);
		}
		Refresh ();
	}
	//
	public void OnExcute()
	{
		foreach (var item in pairId2Instance.Values) {
			item.OnExecute ();
		}
	}
	public void OnExit()
	{
		foreach (var item in pairId2Instance.Values) {
			item.OnExit ();
		}
		pairId2Instance.Clear ();
	}
	int GetPairID(string name,string name2)
	{
		int id = name2Id [name];
		int id2 = name2Id [name2];
		if (id < id2) {
			return (id << 8) + id2;
		}
		return (id2 << 8) + id;
	}

	int max = 20;
	List<int> poolList = new List<int>();
	Dictionary<int,GraphCanvasType> selectionPool = new Dictionary<int, GraphCanvasType> ();
	public GraphCanvasType LoadSectionByID(int pairId,int id)
	{
		int aid = (pairId << 8) + id;
		int index = poolList.IndexOf (aid);
		if (index == -1) {
			GraphCanvasType c = Resources.Load<GraphCanvasType> ("Sections/" + pairId.ToString () + "/" + id.ToString ());
			c.sectionID = id;
			for (int i = 0; i < c.nodes.Count; i++) {
				c.nodes [i].nodeId = i;
				c.nodes [i].sectionId = id;
			}
			poolList.Add (aid);
			selectionPool.Add (aid,c);
			return c;
		}
		poolList.RemoveAt (index);
		poolList.Add (index);
		return selectionPool[aid];
	}
	void CleanPool(int maxCount)
	{
		if (poolList.Count <= maxCount)
			return;
		int need2CleanNum = poolList.Count - maxCount;
		for (int i = 0; i < need2CleanNum; i++) {
			bool isUsing = false;
			foreach (var item in pairId2Instance.Values) {
				if (item.CheckIfUsing (poolList [0])) {
					isUsing = true;
					break;
				}
			}
			if (!isUsing) {
				selectionPool.Remove (poolList[0]);
				poolList.RemoveAt (0);
			}
		}
	}
}
