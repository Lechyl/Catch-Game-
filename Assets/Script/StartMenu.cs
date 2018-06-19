using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {


    public Button playB;
    public Button exitB;
    public Button highScore;

	// Use this for initialization
	void Start () {
        playB.onClick.AddListener(() =>
        {
            
            SceneManager.LoadScene("SampleScene");
        });

        highScore.onClick.AddListener(() =>
        {

            SceneManager.LoadScene("HighScoreScene");
        });

        exitB.onClick.AddListener(() =>
        {
            Application.Quit();
            
        });

	}
	
}
