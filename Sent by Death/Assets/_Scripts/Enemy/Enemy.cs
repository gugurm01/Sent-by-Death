using EZCameraShake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int vidas;
    public ParticleSystem particula;


    public GameObject projectile;
    public Transform playerPos, firePos;
    public int damage;
    public float cooldown;
    public float projectileForce;
    void Start()
    {
        StartCoroutine(ShootPlayer());
        cooldown = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        vidas -= damage;
        if (vidas <= 0)
        {
            ParticleSystem explosão = Instantiate(this.particula, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            Destroy(explosão.gameObject, 1f);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            CameraShaker.Instance.ShakeOnce(3f, 3f, 0.2f, 0.2f);
            TakeDamage(bullet.Instance.dano);
        }
    }

    public IEnumerator ShootPlayer()
    {
        cooldown = Random.Range(1, 4);
        yield return new WaitForSeconds(cooldown);
        if(playerPos != null)
        {
            Instantiate(projectile, firePos.position, firePos.rotation);
            Vector2 myPos = transform.position;
            Vector2 targetPos = playerPos.position;
            Vector2 dir = (targetPos - myPos).normalized;
            StartCoroutine(ShootPlayer());
        }
    }
}
