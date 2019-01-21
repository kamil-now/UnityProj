using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBlueCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Box1")
        {
            Debug.Log("trigger detected!");
            MainEventStorage.BlueTriggersCount += 1;
            checkIfBorderCanBeUnlocked();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Box1")
        {
            Debug.Log("trigger leave!");
            MainEventStorage.BlueTriggersCount -= 1;
            checkIfBorderCanBeUnlocked();
        }
    }

    private void checkIfBorderCanBeUnlocked()
    {
        var borderToOpen = GameObject.FindWithTag("2FinalGate");
        Debug.Log(MainEventStorage.BlueTriggersCount);

        if (MainEventStorage.BlueTriggersCount == 6)
        {
            borderToOpen.GetComponent<SpriteRenderer>().sortingOrder = 0;
			borderToOpen.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            borderToOpen.GetComponent<SpriteRenderer>().sortingOrder = 2;
			borderToOpen.GetComponent<BoxCollider2D>().enabled = true;
		}
    }
}
