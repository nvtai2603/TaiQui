using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;


public class PaulGetDame : MonoBehaviour
{
    // S? máu c?a Paul
    public static event Action OnPlayerDeath;
    public Animator animator;
    public int maxHealth = 100;
    public float currentHealth;
    private float lerpTimer;
    public float chipSpeed = 2f;
    public Image frontHealthBar;
    public Image backHealthBar;
    public TextMeshProUGUI HpText;

    [Header("Sound")]
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip healSound;



    void Start()
    {
        currentHealth = maxHealth;

    }
    void Update()
    {
        HpText.text = Mathf.Round(currentHealth) + "/" + Mathf.Round(maxHealth);
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();
    }
    public void UpdateHealthUI()
    {

        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = currentHealth / maxHealth;
        if (fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        if (fillF < hFraction)
        {
            backHealthBar.color = Color.red;
            backHealthBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, percentComplete);
        }
    }
    public void TakeDame(int dame)
    {
        currentHealth -= dame;
        lerpTimer = 0f;
        animator.SetTrigger("BiDanh");
        SoundManager.instance.PlaySound(hurtSound);
        if (currentHealth <= 0)
        {
            Chet();
        }
    }
    void Chet()
    {
        animator.SetBool("Chet", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        OnPlayerDeath?.Invoke();
        SoundManager.instance.PlaySound(deathSound);
    }
    // Tao chuc nang hoi mau khi an dc vien mau
    public void addHealth(int healthAmount)
    {
        currentHealth += healthAmount;
        lerpTimer = 0f;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        SoundManager.instance.PlaySound(healSound);
    }
    public void IncreaseHealth(int level)
    {
        maxHealth += Mathf.RoundToInt((currentHealth * 0.01f) * ((100 - level) * 0.1f));
        currentHealth = maxHealth;
    }
}
