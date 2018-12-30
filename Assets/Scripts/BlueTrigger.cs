using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
    {

		if (tag == "Blue1") {
			MainEventStorage.BoxCoverBlueFirst = true;
			checkIfCrossBorderCanBeOpened(); 
		} else if(tag == "Blue2") {
			MainEventStorage.BoxCoverBlueSecond = true;
			checkIfCrossBorderCanBeOpened(); 
		} else if(tag == "Blue3") {
			MainEventStorage.BoxCoverBlueThird = true;
			checkIfCrossBorderCanBeOpened(); 
		}
    }

	private void checkIfCrossBorderCanBeOpened() {

		var coverBlueFirst = MainEventStorage.BoxCoverBlueFirst;
		var coverBlueSecond = MainEventStorage.BoxCoverBlueSecond;
		var coverBlueThird = MainEventStorage.BoxCoverBlueThird;

		if (coverBlueFirst && coverBlueSecond && coverBlueThird) {
			var borderToOpen = GameObject.FindWithTag("FinalGate1");
			var secondBorderToOpen = GameObject.FindWithTag("FinalGate2");
			Destroy(borderToOpen);
			Destroy(secondBorderToOpen);
		}
	}
}
