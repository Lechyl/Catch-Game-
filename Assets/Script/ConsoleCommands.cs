using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class ConsoleCommands : MonoBehaviour {

    public Text lifeScore;
    public Text consoleLog;
    public Text consoleInput;
    public Button enterB;
    public string[] strArray;

    // Use this for initialization
    void Start () {
        Button btn = enterB.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskOnClick()
    {
        string input = consoleInput.text;
        strArray = consoleInput.text.Split(" "[0]);
        string command = strArray[0];
        string value = "";
        if(strArray.Length > 1)
        {
            value = strArray[1];
        }
        consoleInput.text = "shitt";

        switch (command.ToLower())
        {
            
            case "restart":
                SceneManager.LoadScene("SampleScene");
                break;
            case "life":



                try
                {
                    var x = 0;
                    Debug.Log("This is before: " + value);
                    int.TryParse(value, out x);
                    
                   // int i = int.Parse(value);
                    Type t = x.GetType();
                    Debug.Log("This is after: " + value);
                   
                    if (t == typeof(string))
                    {
                        consoleLog.text += "This ' ' after life doesn't exist " + Environment.NewLine;
                        Debug.Log("string");
                    }
                    if (t == typeof(char))
                    {
                        consoleLog.text += "This ' ' after life doesn't exist " + Environment.NewLine;
                        Debug.Log("char");
                    }
                    if (t == typeof(bool))
                    {
                        consoleLog.text += "This ' ' after life doesn't exist " + Environment.NewLine;
                        Debug.Log("b00l");
                    }
                    if (t == typeof(int))
                    {
                        lifeScore.text = value;
                    }
                    

                    if (value == "" || int.Parse(value) > 40 || int.Parse(value) < 3)
                    {
                        Debug.Log("0");
                    }
                    if (value != "")
                    {
                        Debug.Log("0");
                    }


                }
                catch
                {
                    consoleLog.text += "THIS FAIL " + Environment.NewLine;
                    Debug.Log("Catch Exeption Fail");

                }




                break;
            default:
                consoleLog.text += "This Command doesn't exist" + Environment.NewLine ;
                break;
        }
    }

}
