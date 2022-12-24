using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameValues : MonoBehaviour
{
    [SerializeField]
    private FloatSO CoinSO;
    
    private void Start()
    {
        CoinSO.Coin = 0;
    }
}
