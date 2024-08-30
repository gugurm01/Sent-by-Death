using UnityEngine;
using UnityEngine.UI;
using TMPro;
using EZCameraShake;
using System;
using System.Collections;

public class PlayerLife : MonoBehaviour
{
    public static PlayerLife Instance;

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

    IEnumerator Flash()
    {
        spriteRenderer.material = hit;
        weapon.material = hit;
        yield return new WaitForSecondsRealtime(0.2f);
        spriteRenderer.material = normal;
        weapon.material = normal;
    }
}
