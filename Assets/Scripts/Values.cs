using UnityEngine;

public static class Values
{
    //!KN: tutaj wrzucamy wszystkie prametry które nie są zmieniane po starcie gry

    //!KN: index sceny ustawiamy z poziomu Unity File->Build Settings
    public const int MainMenuIndex = 1;
    public const int MainSceneIndex = 2;
    public const int RestartTime = 5;

    public static readonly Quaternion DefaultCameraRotation = new Quaternion(0.7071068f, 0, 0, 0.7071068f);
    public static readonly Vector3 DefaultCameraPosition = new Vector3(0, 10, 5);
}


