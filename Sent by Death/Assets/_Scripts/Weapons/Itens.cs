using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itens : MonoBehaviour
{
    public static Itens Instance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseLife(int lifeIncrease)
    {
        PlayerLife.Instance.maxHealth += lifeIncrease;
        PlayerLife.Instance.Heal();
    }

    public void IncreaseSpeed(int speedIncrease)
    {
        PlayerMove.Instance.speed += speedIncrease;
    }

    public void IncreaseDashSpeed(int dashSpeedIncrease)
    {
        PlayerMove.Instance.rollSpeed += dashSpeedIncrease;
    }

    public void IncreaseBalas(int damageIncrease)
    {
        GameObject facas = GameObject.FindGameObjectWithTag("Facas");
        GameObject sword = GameObject.FindGameObjectWithTag("Scimitar");

        if (facas == null && sword != null)
        {
            Scmitar.Instance.damage += damageIncrease;
        }
        else if(sword == null && facas != null)
        {
            ShootAndAim.Instance.maxAmmo += 1;
            StartCoroutine(ShootAndAim.Instance.Reload());
        }
    }
}
