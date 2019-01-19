using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (MainEventStorage.runTime)
        {
            MainEventStorage.TimeLeft -= Time.deltaTime;
            Debug.Log("Time left: " + MainEventStorage.TimeLeft);

            if (MainEventStorage.TimeLeft <= 0)
            {
                closeGate();
            }
        }
    }

    private void closeGate()
    {
        var borderToOpen = GameObject.FindWithTag("TwoWaysBorder");
        borderToOpen.GetComponent<SpriteRenderer>().sortingOrder = 2;

        MainEventStorage.runTime = false;
        MainEventStorage.TimeLeft = 30.0f;
		borderToOpen.GetComponent<BoxCollider2D>().enabled = true;
	}
}
