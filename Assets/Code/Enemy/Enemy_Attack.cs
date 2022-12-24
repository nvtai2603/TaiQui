using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    public int attackDamage = 20;
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    [Header("Fireball Sound")]
    [SerializeField] private AudioClip fireballSound;
    public float attackRate = 1.5f;
    float nextAttack = 2f;

    public void Danh()
    {
        SoundManager.instance.PlaySound(fireballSound);
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (Time.time >= nextAttack)
        {
            if (colInfo != null)
            {
                colInfo.GetComponent<PaulGetDame>().TakeDame(attackDamage);
                nextAttack = Time.time + 1f / attackRate;
            }
        }

    }
}
