using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paul_Skill : MonoBehaviour
{
    public float Speed = 10f;
    public int Dame = 20;
    public Rigidbody2D r2d;
    public void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 1.5f);
    }
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * Speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<Kethu>();
        if(enemy)
        {
            enemy.GetComponent<Kethu>().NhanDame(Dame);
        }
        Destroy(gameObject);
    }
}
