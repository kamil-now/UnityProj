using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endgame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(tag);
        if (tag == "2FinalRed")
        {
            MainEventStorage.filledEndGameRedOne = true;
            tryFinishGame();
        }
        else if (tag == "2FinalRed2")
        {
            MainEventStorage.filledEndGameRedTwo = true;
            tryFinishGame();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (tag == "2FinalRed")
        {
            MainEventStorage.filledEndGameRedOne = false;

        }
        else if (tag == "2FinalRed2")
        {
            MainEventStorage.filledEndGameRedTwo = false;

        }
    }

    private void tryFinishGame()
    {
        if (MainEventStorage.filledEndGameRedOne && MainEventStorage.filledEndGameRedTwo)
        {
            Debug.Log("Game finished!");
        }
    }
}
