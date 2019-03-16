using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using System.Xml;
using System.IO;

public class XMLSaver : Singleton<XMLSaver> {
	// Use this for initialization
	public static SaveData saveData;
	public void Save (SaveData data) {
		XmlSerializer serializer = new XmlSerializer (typeof(SaveData));
		FileStream stream = new FileStream (Application.persistentDataPath + "/save.xml", FileMode.Create);
		serializer.Serialize (stream, data);
		stream.Close ();
	}


	public SaveData Load () {
		SaveData data = null;
		if (File.Exists (Application.dataPath + "/save.xml")) {
			XmlSerializer serializer = new XmlSerializer (typeof(SaveData));
			FileStream stream = new FileStream (Application.persistentDataPath + "/save.xml", FileMode.Open);
			data = serializer.Deserialize (stream) as SaveData;
			stream.Close ();
		} else {
			Debug.LogError ("Not Found!");
		}
		return data;
	}
}
