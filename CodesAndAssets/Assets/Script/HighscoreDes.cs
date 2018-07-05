using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using UnityEditor;

public class HighscoreDes : MonoBehaviour {

    List<int> highScoreList = new List<int>();
    public Text highscoreText1;
    public Text highscoreText2;
    public Text highscoreText3;
    public Text highscoreText4;
    public Text highscoreText5;
    public Button exitB;

    // Use this for initialization

    void Start () {
        exitB.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("StartMenu");
        });
        Load();
        highScoreList.Sort();
        highScoreList.Reverse();
        int i = 0;
        foreach (int item in highScoreList)
        {
            
            i++;

            switch (i)
            {
                case 1:
                    highscoreText1.text = item.ToString();
                    break;
                case 2:
                    highscoreText2.text = item.ToString();
                    break;
                case 3:
                    highscoreText3.text = item.ToString();
                    break;
                case 4:
                    highscoreText4.text = item.ToString();
                    break;
                case 5:
                    highscoreText5.text = item.ToString();
                    break;
                
            } //Checking and input one Value from the List to each Textbox
            
        }



    }
	
	// Update is called once per frame
	void FixedUpdate () {


    }

    public void Load()
    {
        if (File.Exists(@"C:\Users\SDE-03062\playerHighScore.bin"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(@"C:\Users\SDE-03062\playerHighScore.bin", FileMode.Open);
            highScoreList = (List<int>)bf.Deserialize(file);
            file.Close();
        }


    }

}
