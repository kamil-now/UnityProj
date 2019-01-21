using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
    {

		if (tag == "FinalRed1") {
			MainEventStorage.playerOneDidCollidWithFinalRed = true;
		} else if(tag == "FinalRed2") {
			MainEventStorage.playerTwoDidCollidWithFinalRed = true;
			tryToFinishScene();
		}
    }

	void OnTriggerExit2D(Collider2D col)
    {
		if (col.tag == "Player1") {
			MainEventStorage.playerOneDidCollidWithFinalRed = false;
			tryToFinishScene();
		} else if(col.tag == "Player2") {
			MainEventStorage.playerTwoDidCollidWithFinalRed = false;
			tryToFinishScene();
		}
	}

	private void tryToFinishScene() {

		var playerOne = MainEventStorage.playerOneDidCollidWithFinalRed;
		var playerTwo = MainEventStorage.playerTwoDidCollidWithFinalRed;

        Debug.Log(playerOne);
        Debug.Log(playerTwo);

		if (playerOne && playerTwo) {
            SceneManager.LoadSceneAsync("SecondMap");
		}
	}
}
