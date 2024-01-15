using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float delayTime;
    public static GameManager Instance { get; private set; }
    [SerializeField] int score;

    Heath _health;
    AudioSourceController _soundController;
    [SerializeField] AudioSource gameOverSound;
    InputInterface _inputInterface;



    public int Score { get { return score; } set { score = value; } }


    private void Awake()
    {
        GameManagerSingleton();
        _health = FindObjectOfType<PlayerController>().GetComponent<Heath>();
        _soundController = FindObjectOfType<AudioSourceController>().GetComponent<AudioSourceController>();

    }

  
    private void GameManagerSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (Instance != null)
        {
            Destroy(this.gameObject);
        }
    }


    public void LoadScene(int levelIndex=0)
    {
        StartCoroutine(LoadSceneAsyn(levelIndex));
    }

    private IEnumerator LoadSceneAsyn(int levelIndex)
    {
        yield return new WaitForSeconds(delayTime);
        yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + levelIndex);
        Score = 0;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}


