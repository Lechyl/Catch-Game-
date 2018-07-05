using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ConsoleScript : MonoBehaviour {

    public Text consoleLog;
    public Text consoleInput;
    public Button enterB;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(consoleLog);
        Button btn = enterB.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
        
        
	}

    void TaskOnClick()
    {
        consoleLog.text += consoleInput.text + Environment.NewLine;
        Debug.Log("You have clicked the button!");
    }
}
