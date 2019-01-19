using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEventStorage {

	public static bool playerStaysOnRedCross = false;
	public static bool playerStaysOnRedStart = false;

	public static bool BoxCoverBlueFirst = false;
	public static bool BoxCoverBlueSecond = false;
	public static bool BoxCoverBlueThird = false;

	public static bool playerOneDidCollidWithFinalRed = false;
	public static bool playerTwoDidCollidWithFinalRed = false;

    public static float TimeLeft = 30.0f;
    public static bool runTime = false;

}

public class Unlocker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
    {

		if (tag == "RedStart") {
			Debug.Log("Player opened start border");
			var borderToOpen = GameObject.FindWithTag("StartBorder");
			MainEventStorage.playerStaysOnRedStart = true;
			checkIfCrossBorderCanBeOpened();
            borderToOpen.GetComponent<SpriteRenderer>().sortingOrder = 0;
			borderToOpen.GetComponent<BoxCollider2D>().enabled = false;

        } else if(tag == "RedCross") {
			Debug.Log("Player enter on red cross border");
			MainEventStorage.playerStaysOnRedCross = true;
            var borderToOpen = GameObject.FindWithTag("HardCross");
            borderToOpen.GetComponent<SpriteRenderer>().sortingOrder = 0;
			borderToOpen.GetComponent<BoxCollider2D>().enabled = false;
			checkIfCrossBorderCanBeOpened();
		}
    }

	void OnTriggerExit2D(Collider2D col)
    {
		if (tag == "RedStart") { 
			MainEventStorage.playerStaysOnRedStart = false;
            var borderToClose = GameObject.FindWithTag("StartBorder");
            borderToClose.GetComponent<SpriteRenderer>().sortingOrder = 2;
         //   MainEventStorage.playerStaysOnRedStart = true;
            checkIfCrossBorderCanBeOpened();
            borderToClose.SetActive(true);
			borderToClose.GetComponent<BoxCollider2D>().enabled = true;
			Debug.Log("Player leave red start border");

		}
		else if (tag == "RedCross") {
			MainEventStorage.playerStaysOnRedCross = false;
			var borderToOpen = GameObject.FindWithTag("HardCross");
			borderToOpen.GetComponent<SpriteRenderer>().sortingOrder = 2;
		//	MainEventStorage.playerStaysOnRedCross = true;
			checkIfCrossBorderCanBeOpened();
			borderToOpen.SetActive(true);
			borderToOpen.GetComponent<BoxCollider2D>().enabled = true;
			Debug.Log("Player leave red cross border");
			
            
            
        }
	}

	private void checkIfCrossBorderCanBeOpened() {

		var isPlayerOnRedStart = MainEventStorage.playerStaysOnRedStart;
		var isPlayerOnRedCross = MainEventStorage.playerStaysOnRedCross;

		if (isPlayerOnRedStart && isPlayerOnRedCross) {
			var borderToOpen = GameObject.FindWithTag("TwoWaysBorder");
            borderToOpen.GetComponent<SpriteRenderer>().sortingOrder = 0;
			borderToOpen.GetComponent<BoxCollider2D>().enabled = false;
		//	borderToOpen.SetActive(false);
			MainEventStorage.runTime = true;
		}
	}
}
