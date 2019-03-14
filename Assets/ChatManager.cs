using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Standard;
public class ChatManager {
	public static ChatManager Instance;
	string curName = "";
	ChatInstance curInstance;
	public Dictionary<string,int> name2Id = new Dictionary<string, int> {
		{ "Tom",0 },
		{ "Jenny",0 },
	};
	Dictionary<int,ChatInstance> pairId2Instance = new Dictionary<int, ChatInstance> ();
	public void EnterInstance(int pairId)
	{
		curInstance.OnExit ();
		curInstance = pairId2Instance [pairId];
		curInstance.OnEnter ();
	}
	public void OnEnter(string name)
	{
		pairId2Instance.Clear ();
		for (int i = 0; i < 11; i++) {
			int id = GetPairID (curName,"");
			ChatInstance instance = new ChatInstance ();
			instance.GetLastSentence ();
			pairId2Instance.Add (id,instance);
		}
	}
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
