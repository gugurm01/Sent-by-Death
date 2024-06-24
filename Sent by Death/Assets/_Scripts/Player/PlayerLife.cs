using UnityEngine;
using UnityEngine.UI;
using TMPro;
using EZCameraShake;

public class PlayerLife : MonoBehaviour
{
    public static PlayerLife Instance;

    public GameObject gameOverPanel;

    public int health;
    public int maxHealth;
    public float lerpSpeed = 0.5f;

    public Slider healthSlider;
    public Slider easeHealthSlider;
    public TextMeshProUGUI healthText;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Time.timeScale = 1.0f;
        healthSlider.value = health;
    }
    void Update()
    {
        if (healthSlider.value != easeHealthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value - 1, healthSlider.value, lerpSpeed);
        }

        healthText.text = health.ToString("0|") + maxHealth.ToString();
        healthSlider.value = health;
    }

    public void TakeDamage(int dano)
    {
        CameraShaker.Instance.ShakeOnce(10f, 10f, .3f, .3f);
        health -= dano;
        if (health <= 0)
        {
            gameOverPanel.SetActive(true);
            TimeStop();
        }
    }

    private void TimeStop()
    {
        Time.timeScale = 0;
    }
}
