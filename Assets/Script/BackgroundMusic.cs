using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour {

    // Use this for initialization
    private static BackgroundMusic instance = null;

    public static BackgroundMusic Instance
    {
        get { return instance; }
    }
    private void Awake()
    {

        GetComponent<AudioSource>().loop = true;
        GetComponent<AudioSource>().time = GetComponent<AudioSource>().clip.length * 0.05f; // starting from 13.80444 secounds
        if (instance != null && instance != this) 
        {
            Destroy(this.gameObject);
            return;
        } 
        else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);


    }


    private void Update()
    {
      // Debug.Log(GetComponent<AudioSource>().time); // See current play time of Soundtrack
    }



}
