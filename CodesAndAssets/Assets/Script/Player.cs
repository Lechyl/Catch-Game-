using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

[Serializable]
public class Player : MonoBehaviour {


    //bool 
    private bool pausePanel = false;
    
    //float
    public float movementSpeed;
    public float timer;

    private float maxSpeed;
    private float defaultTimer;
    float defaultMovementSpeed;


    //public GameObject
    public GameObject sphere;
    public GameObject bomb;
    public GameObject[] spawnPoint;

    //public Button
    public Button btn;

    //public Text
    public Text score;
    public Text lifeScore;
    public Text loseMessage;
    public Text levelMessage;
    public Text comboMessage;
    public Text maxComboMessage;
    public Text test;

    //public int
    public int amountOfSpawnPoints;

    //private int
    private int counter;
    private int levelCounter;
    private int testLifeCounter;
    private int resetCounter;
    private int currentCombo;
    private int currentLife;
    private int currentMaxCombo;
    private int chosenSpawnPoint;

    //lists
    List<int> highScoreList = new List<int>();
    




    

	// Use this for initialization
	public void Start () {

        Time.timeScale = 1.0f;

        Vector3 startPos = new Vector3(0.01f, -3.360001f, -0.0314405f);

        this.transform.position = startPos;

        Load();

        maxSpeed = movementSpeed * 2;

        maxComboMessage.enabled = false;

        defaultMovementSpeed = movementSpeed;

        testLifeCounter = int.Parse(lifeScore.text);

        counter = 0;

        currentLife = testLifeCounter;

        
        if (!sphere)
        {
            Debug.Log("Warning!: Sphere is not set in the inspector menu!");
        }
        SetCounterText();
        defaultTimer = timer;


	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausePanel)
            {
                PauseGame();
            }
            else if (pausePanel)
            {
                ContinueGame();
            }
        }

    }

    public void FixedUpdate()
    {
        btn.onClick.AddListener(ButtonEventTrigger);


        ExtraSpeed();

        Movement();

        highscoreAdd();


        TimeCountDown();



        SetCounterText();


        SpawnAndEnd();


    }
    void Movement()
    {
        if (testLifeCounter > 0)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.Translate(Vector3.left * Time.deltaTime * movementSpeed);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.Translate(Vector3.right * Time.deltaTime * movementSpeed);
            }
        }
    } // Movement for Player
    
    private void OnCollisionEnter(Collision col)
    {
       if(col.gameObject.name == "AnimeSphere(Clone)")
        {
            Destroy(col.gameObject);
            if (testLifeCounter > 0)
            {
                counter++;
                resetCounter++;

                currentCombo++;
            }
            
        }
       if(col.gameObject.name == "BombSphere(Clone)")
        {
            Destroy(col.gameObject);

            testLifeCounter--;

            lifeScore.text = testLifeCounter.ToString();
            

        }

        SetCounterText();


    } // Check if Player Collide with Object

    void SetCounterText()
    {
        if(currentMaxCombo <= currentCombo)
        {
            currentMaxCombo = currentCombo;
        }

        if (testLifeCounter != currentLife)
        {
            currentLife = testLifeCounter;
            currentCombo = 0;
        }

        testLifeCounter = int.Parse(lifeScore.text);


        score.text = "Score: " + counter.ToString();
        comboMessage.text = "Combo: x"+ currentCombo.ToString();
        
        LoopSetLevelxSpeedCounter();


    } // Set Data units to GUIText

    void ButtonEventTrigger()
    {
        loseMessage.enabled = false;
        currentLife = int.Parse(lifeScore.text);
        PauseGame();

    }

    void LoopSetLevelxSpeedCounter()
    {
        int nextLevel = 10;
        int resetLevelCounter = 0;

        if (resetCounter == nextLevel)
        {
            resetCounter = 0;
            levelCounter++;
            resetLevelCounter++;
        }
        if(resetLevelCounter % 2 == 1)
        {
            defaultTimer = defaultTimer - 0.1f;
            resetLevelCounter = 0;
            
        }

        levelMessage.text = "Level: " + levelCounter.ToString();
    } //Check and set level according to your score, 10 score = 1 level And adjust Spawn unit speed to Level

    void highscoreAdd()
    {
        int i = 0;
        if (testLifeCounter <= 0)
        {
            i++;
            int lowestValue = highScoreList.Min();
            if (i == 1)
            {

                if (counter > lowestValue)
                {
                    if (highScoreList.Count < 5)
                    {
                        highScoreList.Add(counter);
                    }
                    else
                    {

                        highScoreList.Remove(lowestValue);
                        highScoreList.Add(counter);
                    }


                }


                Save();
            }

        }
    } // Add your score to highscore if it's Bigger

    public void Spawn() 
    {
        int randomBomb = UnityEngine.Random.Range(0, 6);
        chosenSpawnPoint = UnityEngine.Random.Range(0, amountOfSpawnPoints);


        if(randomBomb != 5)
        {
            Instantiate(sphere.transform, spawnPoint[chosenSpawnPoint].transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(bomb.transform, spawnPoint[chosenSpawnPoint].transform.position, Quaternion.identity);
        }
        timer = defaultTimer;
    } // Instantiate Spawns

    public  void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(@"C:\Users\SDE-03062\playerHighScore.bin");
        bf.Serialize(file, highScoreList);
        file.Close();
    } //Save Highscore to a file

    public void Load()
    {
        if (File.Exists(@"C:\Users\SDE-03062\playerHighScore.bin"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(@"C:\Users\SDE-03062\playerHighScore.bin", FileMode.Open);
            highScoreList = (List<int>)bf.Deserialize(file);
            file.Close();
        }


    } // Load Highscore to HighscoreList

    private void PauseGame()
    {
        Time.timeScale = 0.0f;
        pausePanel = true;
    } // Pausing Game with Time.timescale = 0

    private void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel =false;
        loseMessage.enabled = false;
        maxComboMessage.enabled = false;
    } // Continue game with Time.timeScale = 1

    private void SpawnAndEnd()
    {
        if (timer <= 0)
        {
            if (testLifeCounter > 0)
            {

                Spawn();

            }
            else
            {


                loseMessage.enabled = true;
                maxComboMessage.enabled = true;

                maxComboMessage.text = "Max Combo: x" + currentMaxCombo.ToString();

            }
        }

    } // Spawn Units and Check if Life < 0 To End Game

    private void TimeCountDown()
    {
        if (timer > 0 && timer < 10)
        {
            timer -= 1 * Time.deltaTime;
        }
    } // The Timer, which Count Timer down in secounds

    private void ExtraSpeed()
    {
        

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {

            movementSpeed = maxSpeed;

        }
        else
        {
            movementSpeed = defaultMovementSpeed;
        }
    } // Hold Shift for Extra Movement Speed

}
