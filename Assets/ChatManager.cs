using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Standard;
public class ChatManager : Singleton<ChatManager> {
	//name name selectionID
	string curName = "";
	ChatInstance curInstance;
	public Dictionary<string,int> name2Id = new Dictionary<string, int> {
		{ "Tom",0 },
		{ "Jenny",0 },
	};
	Dictionary<int,ChatInstance> pairId2Instance = new Dictionary<int, ChatInstance>();
	//
	public Node MoveUp()
	{
		return curInstance.MoveUp ();
	}
	public Node MoveDown()
	{
		return curInstance.MoveDown ();
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
	public Node TryGetOptionNode()
	{
		if (curInstance.curRunningNode is ChatOptionNode) {
			return curInstance.curRunningNode;
		}
		return null;
	}
	//
	public void OnEnter(string name)
	{
		pairId2Instance.Clear ();
		for (int i = 0; i < 11; i++) {
			int id = GetPairID (curName,"");
			ChatInstance instance = new ChatInstance ();
			instance.OnInit (id);
			instance.GetLastSentence ();
			pairId2Instance.Add (id,instance);
		}
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
	public GraphCanvasType GetSelectionByID(int sectionID)
	{
		return null;
	}
	int GetPairID(string name,string name2)
	{
		int id = name2Id [name];
		int id2 = name2Id [name2];
		if (id < id2) {
			return id << 8 + id2;
		}
		return id2 << 8 + id;
	}

	int GetResumeSectionID(int pairId)
	{
		return 1;
	}
	public int GetResumeNodeID(int pairId)
	{
		return 1;
	}
	//Load
	public void LoadSectionByID(int pairId,int id)
	{

	}
}
