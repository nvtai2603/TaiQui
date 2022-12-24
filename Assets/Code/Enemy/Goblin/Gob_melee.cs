using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gob_melee : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float atkCooldown;
    [SerializeField] private float range;
    [SerializeField] private int dame;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;


    private Animator anim;
    private PaulGetDame playerHealth;
    private Gob_Patrol goblinPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        goblinPatrol = GetComponentInParent<Gob_Patrol>();
    }
    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        // Attack khi player di vao range tan cong
        if (PlayerInSight())
        {
            if (cooldownTimer >= atkCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("Attack");
            }
        }
        if (goblinPatrol != null)
        {
            goblinPatrol.enabled = !PlayerInSight();
        }
    }
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<PaulGetDame>();
        }
        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamePlayer()
    {
        if (PlayerInSight())
        {
            playerHealth.TakeDame(dame);
        }
    }
}
