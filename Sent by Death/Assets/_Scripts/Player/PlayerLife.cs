using UnityEngine;
using UnityEngine.UI;
using TMPro;
using EZCameraShake;
using System;
using System.Collections;

public class PlayerLife : MonoBehaviour
{
    public static PlayerLife Instance;

    public ParticleSystem healParticle;

    public bool invunerable;

    public GameObject gameOverPanel;

    public static event Action OnPlayerDamaged;

    [SerializeField] Material normal, hit;

    [SerializeField] SpriteRenderer spriteRenderer, weapon;

    public int health;
    public int maxHealth;
    public float lerpSpeed = 0.5f;

    private void Awake()
    {
        Time.timeScale = 1f;
        Instance = this;
    }

    public void TakeDamage(int dano)
    {
        if (invunerable)
            return;

        CameraShaker.Instance.ShakeOnce(10f, 10f, .3f, .3f);
        health -= dano;
        StartCoroutine(Flash());
        OnPlayerDamaged?.Invoke();
        if (health <= 0)
        {
            health = 0;
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Heal()
    {
        health = maxHealth;
        OnPlayerDamaged?.Invoke();
        StartCoroutine(Flash());
        ParticleSystem explosão = Instantiate(this.healParticle, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
        Destroy(explosão.gameObject, 1f);
    }

    IEnumerator Flash()
    {
        invunerable = true;
        spriteRenderer.material = hit;
        weapon.material = hit;
        yield return new WaitForSecondsRealtime(0.2f);
        spriteRenderer.material = normal;
        weapon.material = normal;
        invunerable = false;
    }
}
