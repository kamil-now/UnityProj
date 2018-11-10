using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //!KN: wrzucamy tutaj wszystkie referencje do obiektów potrzebnych globalnie
    //!dodajemy też zmienne które chcemy zmieniać z poziomu sceny _preload (dajemy jako private z atrybutem [SerializeField])
    private Camera _mainCamera;
    private GameObject _player;
    private bool _gameOver;

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                return new GameManager();
            }
            return _instance;
        }
    }

    public GameObject Player
    {
        get
        {
            if (_player == null)
            {
                _player = GameObject.FindGameObjectWithTag("Player");
            }

            return _player;
        }
    }
    public bool GameOver
    {
        get
        {
            return _gameOver;
        }
    }
    #region MONOBEAHVIOR
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    private void Start()
    {
        SceneManager.LoadSceneAsync(Values.MainMenuIndex);

    }
    #endregion
    public void Restart()
    {
        ScoreManager.Instance.Score = 0;
        SceneManager.LoadScene(Values.MainSceneIndex);
    }
    public void SetGameOver()
    {
        _gameOver = true;
        StartCoroutine(LoadMainMenu());
    }
    private IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(Values.RestartTime);
        SceneManager.LoadScene(Values.MainMenuIndex);
    }
    public void OnSceneLoaded(Camera mainCamera)
    {
        SetupCamera(mainCamera);
        //!KN: tutaj wkonujemy wszystkie metody ustawiające odpowiednie obiekty na swoich miejscach według ustawionych parametrów
    }
    private void SetupCamera(Camera cam)
    {
        _mainCamera = cam;
        _mainCamera.transform.rotation = Values.DefaultCameraRotation;
        _mainCamera.transform.position = Values.DefaultCameraPosition;
        float playerSize = 2 * Player.GetComponent<MeshRenderer>().bounds.size.x;
        float distanceToCamera = Vector3.Distance(Player.transform.position, _mainCamera.transform.position);
    }
    public GameObject GetChildObject(Transform parent, string tag)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            if (child.tag == tag)
            {
                return child.gameObject;
            }
            if (child.childCount > 0)
            {
                var obj = GetChildObject(child, tag);
                if (obj != null)
                    return obj;
            }
        }
        return null;
    }
}
