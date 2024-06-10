using EZCameraShake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    float horizontal, vertical;
    Vector2 moveDir;

    public Slider healthSlider;
    public Slider easeHealthSlider;
    public int maxHealth;
    public int health;
    public float lerpSpeed = 0.5f;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        healthSlider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Speed", Mathf.Abs(moveDir.x != 0 ? moveDir.x : moveDir.y));
;

        moveDir = new Vector2 (horizontal, vertical).normalized;

        rb.velocity = new Vector2(moveDir.x * speed, moveDir.y * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(30);
        }

        if(healthSlider.value != easeHealthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, healthSlider.value, lerpSpeed);
        }

    }

    private void TakeDamage(int dano)
    {
        CameraShaker.Instance.ShakeOnce(6f, 6f, .3f, .3f);
        health -= dano;
        healthSlider.value = health;
        if(health <= 0)
        {
            print("die");
        }
    }
}
