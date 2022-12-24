using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mus_Patrol : MonoBehaviour
{
    [Header("Petrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform mushroom;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Mushroom Animator")]
    [SerializeField] private Animator animator;
    private void Awake()
    {
        initScale = mushroom.localScale;
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (mushroom.position.x >= leftEdge.position.x)
                DiChuyen2Ben(-1);
            else
            {
                Swap();
            }
        }
        else
        {
            if (mushroom.position.x <= rightEdge.position.x)
                DiChuyen2Ben(1);
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
        idleTimer = 0;
        animator.SetBool("moving", true);
        mushroom.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);
        mushroom.position = new Vector3(mushroom.position.x + Time.deltaTime * _direction * speed, mushroom.position.y, mushroom.position.z);
    }
}
