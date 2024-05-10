using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scmitar : MonoBehaviour
{
    public Animator anim;

    public float delay = 1.0f;
    private bool block;


    public static bool isAttacking;

    public void ResetIsAttacking()
    {
        isAttacking = false;    
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    public void Attack()
    {

        if (block)
            return;
        anim.SetTrigger("Attack");
        isAttacking = true;
        block = true;
        StartCoroutine(DalayAttack());
    }

    private IEnumerator DalayAttack()
    {
        yield return new WaitForSeconds(delay);
        block = false;
    }
}
