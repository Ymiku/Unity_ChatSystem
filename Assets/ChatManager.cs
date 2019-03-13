using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Standard;
public class ChatManager{
	//name1 name2 section
	public static ChatManager Instance;
	int curPairID = 0;
	Node curRunningNode;
	Node curFocusNode;
	NodeCanvas curCanvas;
	public Dictionary<string,int> name2Id = new Dictionary<string, int> {
		{ "Tom",0 },
		{ "Jenny",0 },
	};
	public void Enter(string name,string name2)
	{
		curPairID = GetPairID (name,name2);
	}
	public Node GetNodeByID(int nodeID)
	{
		return null;
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

	int GetResumeSectionID()
	{
		return 1;
	}
	public int GetResumeNodeID()
	{
		return 1;
	}
	void SetResumeSectionID()
	{
		
	}
	void SetResumeNodeID()
	{
		
	}
	//Load
	void LoadByAssetID(int id)
	{
		
	}
}
