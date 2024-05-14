using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAndAim : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int currentAmmo = -1;

    [SerializeField] float reloadTime;
    [SerializeField] int maxAmmo;
    bool isReloading = false;
    public Animator anim;

    public void Start()
    {
        if(currentAmmo == -1)
        {
            currentAmmo = maxAmmo;
        }
    }
    void Update()
    {
        if (isReloading)
            return;

        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            
        }
        
        
    }

    IEnumerator Reload()
    {
        isReloading = true;
        print("reload");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
    void Shoot()
    {
        anim.SetTrigger("Fire");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        currentAmmo--;
    }
}
