using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTrigger : MonoBehaviour {

    //public float TimeLeft = 5.0f;
    //bool runTime = false;

	// Use this for initialization
	void Start () {

      
    }
	
	// Update is called once per frame
	void Update () {
   

    }

	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Box1") {

            Debug.Log("BOX!");

            switch (tag)
            {
                case "Blue1":
                    MainEventStorage.BoxCoverBlueFirst = true;
                    checkIfCrossBorderCanBeOpened();
                    break;
                case "Blue2":
                    MainEventStorage.BoxCoverBlueSecond = true;
                    checkIfCrossBorderCanBeOpened();
                    break;
                case "Blue3":
                    MainEventStorage.BoxCoverBlueThird = true;
                    checkIfCrossBorderCanBeOpened();
                    break;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Box1")
        {

            Debug.Log("BOX exit!");

            switch (tag)
            {
                case "Blue1":
                    MainEventStorage.BoxCoverBlueFirst = false;
                    checkIfCrossBorderCanBeOpened();
                    break;
                case "Blue2":
                    MainEventStorage.BoxCoverBlueSecond = false;
                    checkIfCrossBorderCanBeOpened();
                    break;
                case "Blue3":
                    MainEventStorage.BoxCoverBlueThird = false;
                    checkIfCrossBorderCanBeOpened();
                    break;
            }
        }
    }

    private void checkIfCrossBorderCanBeOpened() {

		var coverBlueFirst = MainEventStorage.BoxCoverBlueFirst;
		var coverBlueSecond = MainEventStorage.BoxCoverBlueSecond;
		var coverBlueThird = MainEventStorage.BoxCoverBlueThird;

		if (coverBlueFirst && coverBlueSecond && coverBlueThird) {
			var borderToOpen = GameObject.FindWithTag("FinalGate1");
			var secondBorderToOpen = GameObject.FindWithTag("FinalGate2");
            borderToOpen.GetComponent<SpriteRenderer>().sortingOrder = 0;
            secondBorderToOpen.GetComponent<SpriteRenderer>().sortingOrder = 0;
		}
	}
}
