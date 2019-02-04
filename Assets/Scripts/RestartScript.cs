using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour {

    public void RestartGame()
    {
        Scene scene;
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

        MainEventStorage.playerStaysOnRedCross = false;
        MainEventStorage.playerStaysOnRedStart = false;

        MainEventStorage.runTime = false;
        MainEventStorage.TimeLeft = 30.0f;

        MainEventStorage.BoxCoverBlueFirst = false;
        MainEventStorage.BoxCoverBlueSecond = false;
        MainEventStorage.BoxCoverBlueThird = false;
        MainEventStorage.BlueTriggersCount = 0;
        
    }
}
