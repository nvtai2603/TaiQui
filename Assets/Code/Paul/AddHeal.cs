using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHeal : MonoBehaviour
{
    public float healthAmount;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PaulGetDame thePlayerHealth = collision.GetComponent<PaulGetDame>();
            thePlayerHealth.addHealth((int)healthAmount);
            Destroy(gameObject);
        }
    }
}
