using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PaulCombat : MonoBehaviour
{
    public Animator animator;
    public Transform DiemDanh;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int Dame = 0;
    private Rigidbody2D r2d;
    public Transform LaunchOffset;
    public Transform LaunchOffset2;
    public Transform LaunchOffset3;
    public Paul_Skill Skill;
    public Paul_Skill Skill2;
    public Paul_Skill Skill3;



    [Header("Ability 1")]
    [SerializeField]
    private AudioClip atkSound;
    public Image abilityImage1;
    public float cooldown1 = 0.8f;
    bool isCooldown1 = false;

    [Header ("Ability 2")]
    [SerializeField]
    private AudioClip Skill1Sound;
    public Image abilityImage2;
    public float cooldown2 = 3f;
    bool isCooldown2 = false;

    [Header("Ability 3")]
    [SerializeField]
    private AudioClip Skill2Sound;
    public Image abilityImage3;
    public float cooldown3 = 3f;
    bool isCooldown3 = false;

    [Header("Ability 4")]
    [SerializeField]
    private AudioClip Skill3Sound;
    public Image abilityImage4;
    public float cooldown4 = 3f;
    bool isCooldown4 = false;

    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
        abilityImage3.fillAmount = 0;
        abilityImage4.fillAmount = 0;

    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.J) && isCooldown1 == false)
        {
            isCooldown1 = true;
            abilityImage1.fillAmount = 1;
            Danh();
        }
        if (isCooldown1)
        {
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;

            if (abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                isCooldown1 = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.K) && isCooldown2 == false)
        {
            isCooldown2 = true;
            abilityImage2.fillAmount = 1;
            UseSkill();
        }
        if (isCooldown2)
        {          
            abilityImage2.fillAmount -= 1 / cooldown2 * Time.deltaTime;
            
            if (abilityImage2.fillAmount <= 0)
            {               
                abilityImage2.fillAmount = 0;
                isCooldown2 = false;                
            }
        }
        if (Input.GetKeyDown(KeyCode.L) && isCooldown3 == false)
        {
            isCooldown3 = true;
            abilityImage3.fillAmount = 1;
            UseSkill2();
        }
        if (isCooldown3)
        {
            abilityImage3.fillAmount -= 1 / cooldown3 * Time.deltaTime;

            if (abilityImage3.fillAmount <= 0)
            {
                abilityImage3.fillAmount = 0;
                isCooldown3 = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.U) && isCooldown4 == false)
        {
            isCooldown4 = true;
            abilityImage4.fillAmount = 1;
            UseSkill3();
        }

        if (isCooldown4)
        {
            abilityImage4.fillAmount -= 1 / cooldown4 * Time.deltaTime;

            if (abilityImage4.fillAmount <= 0)
            {
                abilityImage4.fillAmount = 0;
                isCooldown4 = false;
            }
        }

    }
    private void UseSkill()
    {
        SoundManager.instance.PlaySound(Skill1Sound);
        animator.SetTrigger("Danh");
        Instantiate(Skill, LaunchOffset.position, transform.rotation);      
    }
    private void UseSkill2()
    {
        SoundManager.instance.PlaySound(Skill2Sound);
        animator.SetTrigger("Danh");
        Instantiate(Skill2, LaunchOffset2.position, transform.rotation);
    }
    private void UseSkill3()
    {
        SoundManager.instance.PlaySound(Skill3Sound);
        animator.SetTrigger("Danh");
        Instantiate(Skill3, LaunchOffset3.position, transform.rotation);
    }
    private void Danh()
    {
        // Ho?t ?nh ?ánh
        SoundManager.instance.PlaySound(atkSound);
        animator.SetTrigger("Danh");
        // Kho?ng cách vùng t?n công
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(DiemDanh.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Kethu>().NhanDame(Dame);

        }
    }

    private void OnDrawGizmosSelected()
    {
        if (DiemDanh == null) return;
        Gizmos.DrawWireSphere(DiemDanh.position, attackRange);
    }
}
