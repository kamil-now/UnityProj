using UnityEngine;

class MainSceneManager : MonoBehaviour
{
    private void Start()
    {
        if (Camera.main == null)
        {
            Debug.Log("no camera");
        }
        GameManager.Instance.OnSceneLoaded(Camera.main);
    }
    public void Restart()
    {
        GameManager.Instance.Restart();
    }
    public void Quit()
    {
        Application.Quit();
    }
}

