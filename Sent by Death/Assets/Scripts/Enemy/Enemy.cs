using EZCameraShake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int vidas;
    public ParticleSystem particula;
    public CameraShake shake;
    void Start()
    {
        
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
}
