using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Run : StateMachineBehaviour
{
    public float TocDo = 2.5f;
    public float TamDanh = 2.5f;
    Transform player;
    Rigidbody2D rb;
    Enemy kethu;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        kethu = animator.GetComponent<Enemy>();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        kethu.LookAtPlayer();
        float kc = Vector3.Distance(kethu.transform.position, player.position);   
        if (kc < 10)
        {
            Vector2 target = new Vector2(player.position.x, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, TocDo * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
            if (Vector2.Distance(player.position, rb.position) <= TamDanh)
            {
                animator.SetTrigger("Attack");
            }
        }      
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
