
using UnityEngine;

public class Ske_Patrol : MonoBehaviour
{
    [Header ("Petrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform skeleton;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Skeleton Animator")]
    [SerializeField] private Animator animator;
    private void Awake()
    {
        initScale = skeleton.localScale;
    }

    private void Update()
    {
        if(movingLeft)
        {
            if(skeleton.position.x >= leftEdge.position.x)
            DiChuyen2Ben(-1);
            else
            {
                Swap();
            }
        }
        else
        {
            if (skeleton.position.x <= rightEdge.position.x)
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

        if(idleTimer > idleDuration)
        movingLeft = !movingLeft;
    }
    
    private void DiChuyen2Ben(int _direction)
    {
        idleTimer = 0;
        animator.SetBool("moving", true);
        skeleton.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);
        skeleton.position = new Vector3 (skeleton.position.x + Time.deltaTime * _direction * speed , skeleton.position.y, skeleton.position.z);
    }
}

