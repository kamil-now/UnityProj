using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerViewer : MonoBehaviour {

    public Text timerText;
    private MainEventStorage unlocker;
	// Use this for initialization
	void Start () {
        timerText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {

        timerText.text = "Time Left: " + Mathf.Round(MainEventStorage.TimeLeft);
        
	}
}
