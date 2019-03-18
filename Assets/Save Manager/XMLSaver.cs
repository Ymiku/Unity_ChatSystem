using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using System.Xml;
using System.IO;

public class XMLSaver : Singleton<XMLSaver> {
	// Use this for initialization
	public static SaveData saveData;
	public static void Save () {
		XmlSerializer serializer = new XmlSerializer (typeof(SaveData));
		FileStream stream = new FileStream (Application.persistentDataPath + "/save.xml", FileMode.Create);
		serializer.Serialize (stream, saveData);
		stream.Close ();
	}


	public static void Load () {
		if (File.Exists (Application.dataPath + "/save.xml")) {
			XmlSerializer serializer = new XmlSerializer (typeof(SaveData));
			FileStream stream = new FileStream (Application.persistentDataPath + "/save.xml", FileMode.Open);
			saveData = serializer.Deserialize (stream) as SaveData;
			stream.Close ();
		} else {
			Debug.LogError ("Not Found!");
		}
	}
}
