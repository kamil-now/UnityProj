using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private GameObject _scoreText;
    private int _score;

    private static ScoreManager _instance;
    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ScoreManager();
            }
            return _instance;
        }
    }


    public int Score
    {
        get
        {
            return _score;
        }

        set
        {

            _score = value;
            if (ScoreText != null)
                ScoreText.GetComponent<Text>().text = Score.ToString();
        }
    }
    public GameObject ScoreText
    {
        get
        {
            if (_scoreText == null)
            {
                try
                {

                _scoreText = GameObject.FindGameObjectWithTag("Score");
                }
                catch
                {
                    Debug.Log("No score text object on the scene");
                }
            }

            return _scoreText;
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    public void Start()
    {
        _score = 0;
    }
}
