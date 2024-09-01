using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealFlasks : MonoBehaviour
{
    public int maxFlasks = 6;
    public int currentFlasks;
    public float flaskCooldown = 60f; // 60 segundos
    private float flaskTimer;

    public Slider cooldownSlider;
    public TextMeshProUGUI flaskCount;

    void Start()
    {
        currentFlasks = 2;
        flaskTimer = 0;
        UpdateSlider();
    }

    void Update()
    {
        // Regenerar um frasco a cada 60 segundos
        if (currentFlasks < maxFlasks)
        {
            flaskTimer += Time.deltaTime;
            UpdateSlider();

            if (flaskTimer >= flaskCooldown)
            {
                currentFlasks++;
                flaskTimer = 0;
            }
        }
        if(currentFlasks >= maxFlasks)
        {
            currentFlasks = maxFlasks;
            UpdateSlider();
        }

        // Uso do frasco ao pressionar Tab
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            UseFlask();
        }
    }

    void UseFlask()
    {
        if (currentFlasks > 0)
        {
            currentFlasks--;
            PlayerLife.Instance.Heal();
            UpdateSlider();
        }
    }

    void UpdateSlider()
    {
        flaskCount.text = currentFlasks.ToString();

        if (currentFlasks <= maxFlasks)
        {
            cooldownSlider.value = flaskTimer / flaskCooldown;
        }
        else
        {
            cooldownSlider.value = 1;
        }
    }
}
