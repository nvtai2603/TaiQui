using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Book : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject SkillUI;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.B))
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
        SkillUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Open()
    {
        SkillUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}