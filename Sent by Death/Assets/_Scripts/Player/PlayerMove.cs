using EZCameraShake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum State
{
    Normal,
    Rolling
}

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    float horizontal, vertical;
    Vector2 moveDir;
    public float rollSpeed;
    public float rollDuration, rollCooldown, maxCooldown;
    public GameObject walkSound;

    public bool canDash, isDashing;

    public static PlayerMove player;

    public Animator anim;

    public static State state;

    void Start()
    {
        rollCooldown = maxCooldown;
        canDash = true;
        state = State.Normal;
        player = this;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        switch (state) 
        {
            case State.Normal:
                Movement();
                break;

            case State.Rolling:
                StartCoroutine(Roll());
                break;
        }
    }

    IEnumerator Roll()
    {
        canDash = false;
        moveDir = new Vector2(horizontal, vertical).normalized;
        rb.velocity = moveDir * rollSpeed;
        yield return new WaitForSeconds(rollDuration);
        state = State.Normal;

        yield return new WaitForSeconds(rollCooldown);
        canDash = true;
        rollCooldown = maxCooldown;
    }

    void Movement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Speed", Mathf.Abs(moveDir.x != 0 ? moveDir.x : moveDir.y));

        moveDir = new Vector2(horizontal, vertical).normalized;

        rb.velocity = moveDir * speed;

        if(Mathf.Abs(moveDir.x != 0 ? moveDir.x : moveDir.y) > 0)
        {
            walkSound.SetActive(true);
        }
        else 
        { 
            walkSound.SetActive(false); 
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (!canDash)
                return;
            state = State.Rolling;
        }
    }
}
