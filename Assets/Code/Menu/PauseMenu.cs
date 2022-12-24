using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused=false;
    public GameObject pauseMenuUi;

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Continue();
            }else
            {
                Pause();
            }
        }
    }
     public void Continue()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
