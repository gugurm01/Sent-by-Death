using EZCameraShake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    float horizontal, vertical;
    Vector2 moveDir;

    public static PlayerMove player;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        player = this;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Speed", Mathf.Abs(moveDir.x != 0 ? moveDir.x : moveDir.y));

        moveDir = new Vector2 (horizontal, vertical).normalized;

        rb.velocity = new Vector2(moveDir.x * speed, moveDir.y * speed);
    }
}
