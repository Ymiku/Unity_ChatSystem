using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using System.Xml;
using System.IO;

public class XMLSaver : MonoBehaviour {
	// Use this for initialization
	SaveData s;
	SaveData b;
	public void Save () {
		XmlSerializer serializer = new XmlSerializer (typeof(SaveData));
		FileStream stream = new FileStream (Application.persistentDataPath + "/save.xml", FileMode.Create);
		serializer.Serialize (stream, s);
		stream.Close ();
	}


	public void Load () {
		if (File.Exists (Application.dataPath + "/save.xml")) {
			XmlSerializer serializer = new XmlSerializer (typeof(SaveData));
			FileStream stream = new FileStream (Application.persistentDataPath + "/save.xml", FileMode.Open);
			b = serializer.Deserialize (stream) as SaveData;
			stream.Close ();
		} else {
			Debug.LogError ("Save Something First");
		}
	}
	void Start () {
		s = new SaveData ();
		s.aa = new List<MyClass2> ();
		s.aa.Add (new MyClass2());
		s.aa[0].a = 1;
		s.aa[0].ss = "asdsdsd";

		Save ();
		Load ();
	
	}

	// Update is called once per frame
	void Update () {
		
	}
}
[System.Serializable]
public class SaveData
{
	
	public List<MyClass2> aa;
}
[System.Serializable]
public class MyClass2
{
	public int a;
	public int b;
	public string ss;
}