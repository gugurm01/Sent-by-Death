using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimPlayer : MonoBehaviour
{
    Vector2 playerVector;
    Transform dir;
    public GameObject gun;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    public void Rotate()
    {
        playerVector = PlayerMove.player.transform.position;
        Vector2 direction = (playerVector - (Vector2)gun.transform.position).normalized;
        gun.transform.right = direction;

    }
}
