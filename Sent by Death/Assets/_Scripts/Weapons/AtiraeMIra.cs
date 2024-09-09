using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AtiraeMIra : MonoBehaviour
{
    public InputAction input;

    [SerializeField] private GameObject gun;

    public Vector2 move;

    public Vector2 worldPosition;
    private Vector2 direction;

    private void Update()
    {
        HandleGunRotation();
    }

    private void HandleGunRotation()
    {
        if(Scmitar.isAttacking == true)
            return;

        move = Gamepad.current.rightStick.ReadValue();

        worldPosition = move;
        direction = move;
        gun.transform.right = direction;

        Vector2 scale = transform.localScale;
        if(direction.x < 0)
        {
            scale.y = -1;
        }
        else if(direction.x > 0)
        {
            scale.y = 1;
        }

        transform.localScale = scale;

        /*if(transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            gunSR.sortingOrder = playerSR.sortingOrder - 1;
            playerSR.flipX = true;
        }
        else 
        {
            gunSR.sortingOrder = playerSR.sortingOrder + 1;
            playerSR.flipX = false;
        }*/
    }
}
