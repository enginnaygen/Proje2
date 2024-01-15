using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class MenuPanel : MonoBehaviour
{
    public void StartButtonClick()
    {
        //SceneManager.LoadScene(0);
        GameManager.Instance.LoadScene(1);
    }

    public void QuitButtonClick() 
    {
        GameManager.Instance.ExitGame();
    }
}
