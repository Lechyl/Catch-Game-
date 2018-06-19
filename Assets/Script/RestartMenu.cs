using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartMenu : MonoBehaviour {

    public GameObject panel;
    public Text counter;
    public Text retryText;
    public Text exitText;
    public Button retryB;
    public Button exitB;
    private bool resume = false;

	// Use this for initialization
	void Start () {
        retryB.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("SampleScene");
        });

        exitB.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("StartMenu");
        });
        panel.gameObject.SetActive(false);

        
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (!resume)
            {
                EndGame();
            }
            else if (resume)
            {
                Resume();
            }

        }
    }

    // Update is called once per frames
    void FixedUpdate () {
        int i = int.Parse(counter.text);
        
        if(i <= 0)
        {
            EndGame();
        }


	}
    void EndGame()
    {
        resume = true;
        retryB.image.enabled = true;
        retryB.enabled = true;
        retryB.interactable = true;
        retryText.enabled = true;
        
        exitB.image.enabled = true;
        exitB.enabled = true;
        exitB.interactable = true;
        exitText.enabled = true;
        panel.gameObject.SetActive(true);


    } //Make GUI Objects Visible as Life < 0

    void Resume()
    {
        resume = false;
        retryB.image.enabled = false;
        retryB.enabled = false;
        retryB.interactable = false;
        retryText.enabled = false;

        exitB.image.enabled = false;
        exitB.enabled = false;
        exitB.interactable = false;
        exitText.enabled = false;
        panel.gameObject.SetActive(false);

    } // if resume = true , If Life > 0 Then Resume game/Continue Game
}
