using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject ShopUI;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            if (GameIsPaused)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
    }
    public void Close()
    {
        ShopUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Open()
    {
        ShopUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
