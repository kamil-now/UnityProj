
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    private GameObject _playBtn;
    private GameObject _scoreTxt;

    private static MainMenuManager _instance;
    public static MainMenuManager Instance
    {
        get { return _instance; }
    }
    

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    private void Start()
    {
        _scoreTxt = GameObject.FindGameObjectWithTag("ScoreTxt");
        _playBtn = GameObject.FindGameObjectWithTag("PlayBtn");

        if (GameManager.Instance.GameOver)
        {
            Debug.Log("GameOver");
            _playBtn.GetComponentInChildren<Text>().text = "PLAY AGAIN";
            _scoreTxt.SetActive(true);
            _scoreTxt.GetComponent<Text>().text += "\n" + ScoreManager.Instance.Score;
        }
        else
        {
            _scoreTxt.SetActive(false);
        }
    }
    public void Play()
    {
        ScoreManager.Instance.Score = 0;
        SceneManager.LoadScene(Values.MainSceneIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
