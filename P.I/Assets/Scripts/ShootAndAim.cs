using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAndAim : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int bulletsGun = 5;
    public GameObject balas1, balas2, balas3, balas4, balas5;

    public void Start()
    {
        reload();
    }
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && bulletsGun >= 1)
        {
            FindObjectOfType<AudioManager>().Play("retrogunshot");
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            StartCoroutine(reload());
            bulletsGun--;
        }
        if (bulletsGun == 0)
        {
            bulletPrefab.SetActive(false);
        }
        if (bulletsGun < 0)
        {
            bulletsGun = 0;
        }
        print(bulletsGun);

        if (bulletsGun == 0)
        {
            balas1.SetActive(false);
            balas2.SetActive(false);
            balas3.SetActive(false);
            balas4.SetActive(false);
            balas5.SetActive(false);
        }
        if (bulletsGun == 1)
        {
            balas1.SetActive(true);
            balas2.SetActive(false);
            balas3.SetActive(false);
            balas4.SetActive(false);
            balas5.SetActive(false);
        }
        if (bulletsGun == 2)
        {
            balas1.SetActive(true);
            balas2.SetActive(true);
            balas3.SetActive(false);
            balas4.SetActive(false);
            balas5.SetActive(false);
        }
        if (bulletsGun == 3)
        {
            balas1.SetActive(true);
            balas2.SetActive(true);
            balas3.SetActive(true);
            balas4.SetActive(false);
            balas5.SetActive(false);
        }
        if (bulletsGun == 4)
        {
            balas1.SetActive(true);
            balas2.SetActive(true);
            balas3.SetActive(true);
            balas4.SetActive(true);
            balas5.SetActive(false);
        }
        if (bulletsGun == 5)
        {
            balas5.SetActive(true);
            balas4.SetActive(true);
            balas3.SetActive(true);
            balas2.SetActive(true);
            balas1.SetActive(true);
        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    IEnumerator reload()
    {
        if (bulletsGun == 1)
        {
            yield return new WaitForSeconds(2);
            bulletsGun = bulletsGun + 5;
            bulletPrefab.SetActive(true);
            balas1.SetActive(false); balas2.SetActive(false); balas3.SetActive(false); balas4.SetActive(false); balas5.SetActive(false);
        }
    }
}
