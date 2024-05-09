using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AtiraeMIra : MonoBehaviour
{
    public SpriteRenderer playerSR, gunSR;

    [SerializeField] private GameObject gun;

    Transform weaponParent;

    private Vector2 worldPosition;
    private Vector2 direction;

    private void Update()
    {
        HandleGunRotation();

    }

    private void HandleGunRotation()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = (worldPosition - (Vector2)gun.transform.position).normalized;
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
    }
}
