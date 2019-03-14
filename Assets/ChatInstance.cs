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
	List<Node> _activeNodes = new List<Node> ();
	public void OnInit(int pairId)
	{

	}
	public void OnEnter()
	{
		_activeNodes.Clear ();
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
	public void PoolUp()
	{
		
	}
	public void PoolDown()
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
