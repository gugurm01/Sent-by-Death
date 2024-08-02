using UnityEngine;
using UnityEngine.UI;
using TMPro;
using EZCameraShake;
using System;

public class PlayerLife : MonoBehaviour
{
    public static PlayerLife Instance;

    public GameObject gameOverPanel;

    public static event Action OnPlayerDamaged;

    public int health;
    public int maxHealth;
    public float lerpSpeed = 0.5f;

    private void Awake()
    {
        Instance = this;
    }

    public void TakeDamage(int dano)
    {
        CameraShaker.Instance.ShakeOnce(10f, 10f, .3f, .3f);
        health -= dano;
        OnPlayerDamaged?.Invoke();
        if (health <= 0)
        {
            health = 0;
            gameOverPanel.SetActive(true);
        }
    }
}
