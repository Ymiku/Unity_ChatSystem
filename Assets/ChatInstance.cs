using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Standard;
public class ChatInstance{
	int curPairID = 0;
	Node curRunningNode;
	Node curFocusNode;
	NodeCanvas curSection;
	public Dictionary<string,int> name2Id = new Dictionary<string, int> {
		{ "Tom",0 },
		{ "Jenny",0 },
	};
	public void OnEnter(string name,string name2)
	{
		
	}
	public void OnExecute()
	{
		
	}
	public void OnExit()
	{
		
	}
	public string GetLastSentence()
	{
		
	}
	public void Bind()
	{
		
	}
	public void MoveUp()
	{
		
	}
	public void MoveDown()
	{
		
	}
	public Node GetNodeByID(int nodeID)
	{
		return null;
	}
	public GraphCanvasType GetSelectionByID(int sectionID)
	{
		return null;
	}

}
