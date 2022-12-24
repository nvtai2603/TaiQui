using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Kethu : MonoBehaviour
{
    public Animator animator;
    private GameObject player;
    LevelSystem playerLevel;
    public int maxHealth = 100;
    public int currentHealth;

    public EnemyHealthBar Healthbar;

    public bool drop;

    public GameObject theDrop;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLevel = player.GetComponent<LevelSystem>();
        currentHealth = maxHealth;
        Healthbar.SetHealth(currentHealth, maxHealth);
    }

    
    public void NhanDame(int dame)
    {      
        currentHealth -= dame;
        Healthbar.SetHealth(currentHealth, maxHealth);
        // Ho?t ?nh nh?n dame
        animator.SetTrigger("NhanDame");
        SoundManager.instance.PlaySound(hurtSound);
        if (currentHealth <= 0)
        { 
            Chet();
        }
    }
    void Chet()
    {
        animator.SetBool("IsDead", true);
        GetComponent<Enemy>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        playerLevel.GainExperienceFlatRate(50f);
        SoundManager.instance.PlaySound(deathSound);
        // Tao ra chuc nang roi ra
        if (drop)
        {
            Instantiate(theDrop, transform.position, transform.rotation);
        }
    }

}
