using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public bool isFlipeped = false;
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipeped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipeped = true;
        }
        else if (transform.position.x < player.position.x && !isFlipeped)
        {
          

            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipeped = false;
        }
    }
}
