using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float spd = 20f;
    public Rigidbody2D rb;
    public int dano;

    public static bullet Instance;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        rb.velocity = transform.right * spd;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }


    private void Update()
    {
        if (transform.position.x >= 20)
        {
            Destroy(gameObject);
        }
    }
}
