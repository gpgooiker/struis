using UnityEngine;
using System.Collections;
using System;

public class GameButtonController : MonoBehaviour {


	public class MyLogHandler : ILogHandler
	{
		public void LogFormat (LogType logType, UnityEngine.Object context, string format, params object[] args)
		{
			Debug.logger.logHandler.LogFormat (logType, context, format, args);
		}

		public void LogException (Exception exception, UnityEngine.Object context)
		{
			Debug.logger.LogException (exception, context);
		}
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnPlayerClickLeft(){
		Logger myLogger = new Logger(new MyLogHandler());

		myLogger.Log("Struis Ops", "You clicked left!");
	}

	public void OnPlayerClickRight(){
		Logger myLogger = new Logger(new MyLogHandler());

		myLogger.Log("Struis Ops", "You clicked right!");
	}
}
