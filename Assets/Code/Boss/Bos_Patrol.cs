using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bos_Patrol : MonoBehaviour
{
    [Header("Petrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform boss;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Boss Animator")]
    [SerializeField] private Animator animator;
    private void Awake()
    {
        initScale = boss.localScale;
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (boss.position.x >= leftEdge.position.x)
                DiChuyen2Ben(1);
            else
            {
                Swap();
            }
        }
        else
        {
            if (boss.position.x <= rightEdge.position.x)
                DiChuyen2Ben(-1);
            else
            {
                Swap();
            }
        }
    }
    private void OnDisable()
    {
        animator.SetBool("moving", false);

    }
    private void Swap()
    {
        animator.SetBool("moving", false);
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }

    private void DiChuyen2Ben(int _direction)
    {
     
        float X= boss.position.x + Time.deltaTime * _direction * speed ;
        idleTimer = 0;
        animator.SetBool("moving", true);
        //Debug.Log("move");
        boss.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);
        boss.position = new Vector3(X, boss.position.y, boss.position.z);
    }
}
