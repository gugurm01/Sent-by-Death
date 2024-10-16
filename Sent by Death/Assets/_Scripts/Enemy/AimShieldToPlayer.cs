using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimShieldToPlayer : MonoBehaviour
{
    public SpriteRenderer playerSR;
    Vector2 playerVector;
    Transform dir;
    public GameObject gun;
    public float rotationSpeed = 2f;  // Velocidade de rota��o (ajuste para mais ou menos atraso)
    private Vector2 currentDirection; // Dire��o atual do inimigo

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    public void Rotate()
    {
        // Pega a posi��o atual do jogador
        playerVector = PlayerMove.player.transform.position;

        // Calcula a dire��o desejada para o inimigo (mirar no jogador)
        Vector2 targetDirection = (playerVector - (Vector2)gun.transform.position).normalized;

        // Suaviza a rota��o atual em dire��o � dire��o desejada com atraso
        currentDirection = Vector2.Lerp(currentDirection, targetDirection, rotationSpeed * Time.deltaTime);

        // Aplica a dire��o suavizada � rota��o do inimigo
        gun.transform.right = currentDirection;

        // Verifica se o inimigo precisa flipar o sprite
        Vector2 scale = transform.localScale;
        transform.localScale = scale;

        // Ajusta o flip do sprite com base no �ngulo de rota��o
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            playerSR.flipX = false;
        }
        else
        {
            playerSR.flipX = true;
        }
    }
}
