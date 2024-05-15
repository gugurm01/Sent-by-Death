using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float spd = 20f;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * spd;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Destroy(collision.gameObject);
        if (collision.CompareTag("Cometa"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().Play("explosion");
        }
        if (collision.CompareTag("SizeUP"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().Play("explosion");
        }
        if (collision.CompareTag("SizeDOWN"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().Play("explosion");
        }
        if (collision.CompareTag("VacasSacanas"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().Play("explosion");
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
