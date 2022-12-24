using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    string scoreKey = "Coin";
    public int currentCoin { get;  set; }
    private void Awake()
    {
        currentCoin = PlayerPrefs.GetInt(scoreKey);
    }

    public void SetCoin(int coin)
    {
        PlayerPrefs.SetInt(scoreKey, coin);
    }

   
}
