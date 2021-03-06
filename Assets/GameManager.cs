﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameManager : UnitySingleton<GameManager> {
	long _timeStamp;
	float _localTime;
	public string curAccountName = "bull";
	public long time{
		get{ return _timeStamp+(long)_localTime;}
	}
	public int localTime{
		get{ return (int)_localTime;}
	}
	void Awake()
	{
		OnEnterGame ();
	}
	void OnEnterGame()
	{
		//load
		XMLSaver.Load();
		_timeStamp = GetTimeStamp ();
		_localTime = 0.0f;
	}
	void OnExitGame()
	{
		XMLSaver.Save ();
	}
	void Update()
	{
		_localTime += Time.deltaTime;
		ChatManager.Instance.OnExcute ();
	}
	public static long GetTimeStamp() 
	{ 
		TimeSpan ts = DateTime.UtcNow - new DateTime(2018, 1, 1, 0, 0, 0, 0); 
		return Convert.ToInt64 (ts.TotalSeconds);
	} 

}
