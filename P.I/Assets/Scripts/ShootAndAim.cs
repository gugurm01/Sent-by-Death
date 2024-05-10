using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAndAim : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int bulletsGun = 5;
    private bool block;
    public float delay;

    public void Start()
    {
        reload();
    }
    void Update()
    {
        if(block == true)
            return;
        if (Input.GetButtonDown("Fire1"))
        {
            if(block == true)
                return;
            Shoot();
            StartCoroutine(reload());
            bulletsGun--;
        }
        
    }
    void Shoot()
    {
        block = true;
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        StartCoroutine(Dalay());
    }

    IEnumerator Dalay()
    {
        yield return new WaitForSeconds(delay);
        block = false;
    }
    IEnumerator reload()
    {
        if (bulletsGun == 1)
        {
            block = true;
            yield return new WaitForSeconds(2);
            block = false;
            bulletsGun = bulletsGun + 5;
            bulletPrefab.SetActive(true);
            
        }
    }
}
