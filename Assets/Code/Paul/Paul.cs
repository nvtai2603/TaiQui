using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using System;
using Unity.VisualScripting;

public class Paul : MonoBehaviour               
{
    public static Paul instance;
    private Animator anim;
    private Rigidbody2D rb;
    private TrailRenderer tr;
    //public ParticleSystem dust;

    [Header("Movement")]
    [SerializeField]
    private float TocDo=0; // T?c ?? c?a Paul
    public float VanToc;
    public float NhayCao=450; // L?y t?c ?? nh?y c?a NV
    public float NhayThap=5; // Áp d?ng khi NV nh?y th?p: nh?n nhanh và buông phím nh?y
    public float RoiXuong=5; // L?c hút r?i xu?ng c?a NV
    private bool DuoiDat = true; // Ki?m tra có ? d??i ??t hay ko
    private bool ChuyenHuong = false; // Ki?m tra Paul có ?ang chuy?n h??ng hay ko
    private bool QuayPhai = true; // Ki?m tra xem NV quay v? h??ng nào
    
   
    [Header("Coin pick up")]
    [SerializeField]
    private AudioClip coinsound;
    public int Coin;
    public TextMeshProUGUI txtCoin;

    [Header("Dash")]
    [SerializeField]
    float doubleTapTime;
    KeyCode lastKeyCode;
    public float dashSpeed;
    private float dashCount;
    public float startDashCount;
    private int side;

   
    void Start()
    {        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();       
        dashCount = startDashCount;

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {
        anim.SetFloat("TocDo", TocDo);
        anim.SetBool("DuoiDat", DuoiDat);
        anim.SetBool("ChuyenHuong", ChuyenHuong);
        DiChuyen();
        
        Nhay();
        
        //Dash
        if(side == 0)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {

                if (doubleTapTime > Time.time && lastKeyCode == KeyCode.A)
                {
                    side = 1;
                }
                else
                {
                    doubleTapTime = Time.time + 0.5f;
                }

                lastKeyCode = KeyCode.A;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (doubleTapTime > Time.time && lastKeyCode == KeyCode.D)
                {
                    side = 2;
                }
                else
                {
                    doubleTapTime = Time.time + 0.5f;
                }

                lastKeyCode = KeyCode.D;
            }
        }
        else
        {
            if (dashCount <= 0)
            {

                side = 0;
                dashCount = startDashCount;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashCount -= Time.deltaTime;
                if (side == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                }
                else if (side == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                }
            }          
        }
    }  
    void DiChuyen()
    {
        float PhimNhanPhaiTrai = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(VanToc * PhimNhanPhaiTrai, rb.velocity.y);
        TocDo = Mathf.Abs(VanToc * PhimNhanPhaiTrai);
        if (PhimNhanPhaiTrai > 0 && !QuayPhai) HuongMatPaul();
        if (PhimNhanPhaiTrai < 0 && QuayPhai) HuongMatPaul();
    }
    void HuongMatPaul()
    {
       // CreatDust();
        QuayPhai = !QuayPhai;
        transform.Rotate(0f, 180f, 0f);
    }

    void Nhay()
    {
        //CreatDust();
        if (Input.GetKeyDown(KeyCode.Space) && DuoiDat == true)
        {
            rb.AddForce((Vector2.up) * NhayCao);
            DuoiDat = false;
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (RoiXuong - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (NhayThap - 1) * Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "NenDat")
        {
            DuoiDat = true;
        }
    }
    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "NenDat")
        {
            DuoiDat = true;
        }
        if (col.tag == "Coin")
        {
            SoundManager.instance.PlaySound(coinsound);
            Coin = Coin + 1;
            txtCoin.text = Coin.ToString();
            
            Destroy(col.gameObject);            
        }
        if (col.tag == "Coin10")
        {
            SoundManager.instance.PlaySound(coinsound);
            Coin = Coin + 10;
            txtCoin.text = Coin.ToString();

            Destroy(col.gameObject);
        }
        if (col.tag == "Coin50")
        {
            SoundManager.instance.PlaySound(coinsound);
            Coin = Coin + 50;
            txtCoin.text = Coin.ToString();

            Destroy(col.gameObject);
        }
        if (col.tag == "Coin100")
        {
            SoundManager.instance.PlaySound(coinsound);
            Coin = Coin + 100;
            txtCoin.text = Coin.ToString();

            Destroy(col.gameObject);
        }
    }

}
