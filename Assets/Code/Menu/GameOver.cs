using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverMenu;
    [Header("Game Over")]
    [SerializeField] private AudioClip gameover;

    private void OnEnable()
    {
        
        PaulGetDame.OnPlayerDeath += EnableGameOverMenu;        
    }
    private void OnDisable()
    {
        PaulGetDame.OnPlayerDeath -= EnableGameOverMenu;
    }
    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        SoundManager.instance.PlaySound(gameover);

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void GotoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
