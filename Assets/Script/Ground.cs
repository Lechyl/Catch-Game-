using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ground : MonoBehaviour {

    public Button btn;
    public Text life;
    public int lifeCounter;

    // Use this for initialization
    void Start() {
        btn.onClick.AddListener(ButtonTrigger);
        lifeCounter = int.Parse(life.text);
        SetLifeCounter();

    }
	
	// Update is called once per frame
	void Update () {

    }

    void ButtonTrigger()
    {
        lifeCounter = int.Parse(life.text);
        SetLifeCounter();
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "AnimeSphere(Clone)")
        {
            lifeCounter = int.Parse(life.text);
            Destroy(col.gameObject);

            if(lifeCounter > 0)
            {
                lifeCounter = int.Parse(life.text);
                lifeCounter--;
                Debug.Log(lifeCounter);
            }

            SetLifeCounter();

        }

        if (col.gameObject.name == "BombSphere(Clone)")
        {
            Destroy(col.gameObject);
            
        }
    }

    void SetLifeCounter()
    {
        life.text = lifeCounter.ToString();

    }
}
