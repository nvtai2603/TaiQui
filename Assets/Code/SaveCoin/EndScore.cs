using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScore : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI txtCoin;
    [SerializeField]
    public FloatSO coinSO;

    private void Start()
    {
        txtCoin.text = coinSO.Coin + "";
    }
}
