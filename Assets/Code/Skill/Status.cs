using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public GameObject status;
    public static bool IsClick = false;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.X))
        {
            if (IsClick)
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
        status.SetActive(false);
        IsClick = false;

    }
    public void Open()
    {
        status.SetActive(true);
        IsClick = true;

    }
}
