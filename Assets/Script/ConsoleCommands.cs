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
    void Start() {
        Button btn = enterB.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update() {

    }

    void TaskOnClick()
    {
        string input = consoleInput.text;
        strArray = consoleInput.text.Split(" "[0]);
        string command = strArray[0];
        string value = "";
        if (strArray.Length > 1)
        {
            value = strArray[1];
        }

        switch (command.ToLower())
        {

            case "restart":
                SceneManager.LoadScene("SampleScene");
                break;

            case "life":
                bool isNotInt = false;
                char[] myChar = value.ToCharArray();
                for (int i = 0; i < value.Length; i++)
                {

                        if (!System.Char.IsDigit(myChar[i]))
                        {
                            isNotInt = true;

                       }

                }
                if (isNotInt == false)
                {
                    if(int.Parse(value) > 0)
                    {
                        lifeScore.text = value;
                        
                    }
                    else
                    {
                        consoleLog.text += "This '' after life is a wrong command" + Environment.NewLine;

                    }

                }

                if(isNotInt == true)
                {

                    consoleLog.text += "This '' after life is a wrong command" + Environment.NewLine;
                    
                }
                break;

            default:
                consoleLog.text += "This Command doesn't exist" + Environment.NewLine;
                break;
        }
    }

}
