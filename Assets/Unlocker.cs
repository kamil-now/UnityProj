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
			Debug.Log("==Player opened start border==");
			var borderToOpen = GameObject.FindWithTag("StartBorder");
			MainEventStorage.playerStaysOnRedStart = true;
			checkIfCrossBorderCanBeOpened(); 
			Destroy(borderToOpen);
		} else if(tag == "RedCross") {
			Debug.Log("Player enter on red cross border");
			MainEventStorage.playerStaysOnRedCross = true;
			checkIfCrossBorderCanBeOpened();
		}
    }

	void OnTriggerExit2D(Collider2D col)
    {
		if (tag == "RedStart") { 
			MainEventStorage.playerStaysOnRedStart = false;
		}
		else if (tag == "RedCross") {
			Debug.Log("Player leave red cross border");
			MainEventStorage.playerStaysOnRedCross = false;
		}
	}

	private void checkIfCrossBorderCanBeOpened() {

		var isPlayerOnRedStart = MainEventStorage.playerStaysOnRedStart;
		var isPlayerOnRedCross = MainEventStorage.playerStaysOnRedCross;

		if (isPlayerOnRedStart && isPlayerOnRedCross) {
			var borderToOpen = GameObject.FindWithTag("TwoWaysBorder");
			Destroy(borderToOpen);
		}
	}
}
