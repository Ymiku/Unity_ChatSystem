using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SaveData
{
	public static SaveData Instance;
	public List<int> instanceID = new List<int> ();
	public List<ChatInstanceData> instanceData = new List<ChatInstanceData> ();
	public List<string> varName = new List<string> ();
	public List<int> varValue = new List<int> ();
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
	public float totalRectHeight;
	public List<int> nodeIds = new List<int>();
	public List<int> nodeOptions = new List<int>();
	//section<<8+id
	public int GetOption(int id)
	{
		int i = nodeIds.IndexOf (id);
		return nodeOptions [i];
	}
}