﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NodeEditorFramework;
using NodeEditorFramework.Standard;

public partial class SaveData
{
	public List<int> instanceID = new List<int> ();
	public List<ChatInstanceData> instanceData = new List<ChatInstanceData> ();

	public List<string> varName = new List<string> ();
	public List<int> varValue = new List<int> ();
	public int GetValue(string valueName)
	{
		int i = varName.IndexOf (valueName);
		if (i != -1)
			return varValue [i];
		return 0;
	}
	public void SetValue(string valueName,int value)
	{
		int i = varName.IndexOf (valueName);
		if (i != -1)
			varValue [i] = value;
		varName.Add (valueName);
		varValue.Add (value);
	}
	public List<string> GetFriendsLst(string name)
	{
		int playerId = ChatManager.Instance.name2Id[name];
		List<string> result = new List<string> ();
		for (int i = 0; i < instanceID.Count; i++) {
			int m = (instanceID [i] >> 8);
			int n = (instanceID [i] & 255);
			if(m!=playerId&&n!=playerId)
				continue;
			if(m==playerId)
				result.Add(ChatManager.Instance.id2Name[n]);
			else
				result.Add(ChatManager.Instance.id2Name[m]);
		}
		return result;
	}
	public ChatInstanceData GetInstanceData(int pairId)
	{
		int i = instanceID.IndexOf (pairId);
		if (i == -1) {
			instanceID.Add (pairId);
			instanceData.Add (new ChatInstanceData());
			i = instanceData.Count - 1;
		}
		return instanceData[i];
	}
	public bool Check(string varname,int varvalue)
	{
		int index = varName.IndexOf(varname);
		if (index == -1) {
			varName.Add (varname);
			varValue.Add (0);
			index = varName.Count - 1;
		}
		return varValue [index] <= varvalue;
	}
}
[System.Serializable]
public class ChatInstanceData
{
	public int curSectionId;
	public int curNodeId;
	public long lastChatTimeStamp;
	public List<int> nodeIds = new List<int>();
	public List<int> nodeOptions = new List<int>();

	public List<int> nodeIdsForHeight = new List<int>();
	//section<<8+id
	public int GetOption(Node node)
	{
		return nodeOptions [nodeIds.IndexOf (node.nodeId+(node.sectionId<<8))];
	}
}