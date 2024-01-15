using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    Heath _health;
    [SerializeField] GameObject gameOverPanel,player;
    [SerializeField] AudioSource gameOverSound;
    AudioSourceController _soundController;
    [SerializeField] AudioClip clip;


    private void Awake()
    {
        _health = FindObjectOfType<PlayerController>().GetComponent<Heath>();
        _soundController = FindObjectOfType<AudioSourceController>().GetComponent<AudioSourceController>();

    }

    private void Update()
    {
        if (_health.IsDead)
        {
            gameOverPanel.SetActive(true);
            player.SetActive(false);
            
        }




    }

    public void YesButtonClick() 
    {
        GameManager.Instance.LoadScene();
        GameManager.Instance.Score = 0;
    }
    public void NoButtonClick()
    {
        //GameManager.Instance.LoadScene(-1);
        SceneManager.LoadScene("Menu");
        GameManager.Instance.Score = 0;

    }
}
