using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] private int dame;

    protected void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<PaulGetDame>().TakeDame(dame);
        }
    }
}
