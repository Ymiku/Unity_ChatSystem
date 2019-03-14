using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Standard;
public class ChatInstance{
	int curPairID = 0;
	public Node curRunningNode;
	Node curFocusNode;
	GraphCanvasType curSection;
	public long lastChatTimeStamp;
	List<Node> _activeNodes = new List<Node> ();
	string userName;
	string otherUserName;
	public string lastSentence;
	public void OnInit(string name,string otherName,int pairId)
	{
		userName = name;
		otherUserName = otherName;
		curPairID = pairId;
	}
	public void OnEnter()
	{
		_activeNodes.Clear ();
	}
	public void OnExecute()
	{
		if (false)
			ChatManager.Instance.Refresh ();
	}
	public void OnExit()
	{
		_activeNodes.Clear ();
	}
	public string GetLastSentence()
	{
		return "";
	}
	public Node MoveUp()
	{
		Node node = null;
		_activeNodes.Insert (0,node);
		return node;
	}
	public Node MoveDown()
	{
		Node node = null;
		_activeNodes.Add (node);
		return node;
	}
	public void PoolUp()
	{
		if (_activeNodes.Count != 0)
			_activeNodes.RemoveAt (0);
	}
	public void PoolDown()
	{
		if (_activeNodes.Count != 0)
			_activeNodes.RemoveAt (_activeNodes.Count-1);
	}
	public Node GetNodeByID(int nodeID)
	{
		return null;
	}
	public GraphCanvasType GetSelectionByID(int sectionID)
	{
		return null;
	}



	//
	long GetLastChatTimeStamp()
	{
		return 1;
	}
	int GetResumeSectionID()
	{
		return 1;
	}
	public int GetResumeNodeID()
	{
		return 1;
	}
	//Load
}
