using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Standard;
public class ChatInstance{
	int curPairID = 0;
	public Node curRunningNode;
	Node curFocusNode;
	NodeCanvas curSection;
	long _lastChatTimeStamp;
	public Dictionary<string,int> name2Id = new Dictionary<string, int> {
		{ "Tom",0 },
		{ "Jenny",0 },
	};
	public void OnInit(int pairId)
	{

	}
	public void OnEnter()
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
		return "";
	}
	public Node MoveUp()
	{
		return null;
	}
	public Node MoveDown()
	{
		return null;
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
