using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SaveData
{
	public List<int> instanceID = new List<int> ();
	public List<ChatInstanceData> instanceData = new List<ChatInstanceData> ();

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