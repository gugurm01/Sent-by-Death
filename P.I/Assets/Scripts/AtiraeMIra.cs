using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AtiraeMIra : MonoBehaviour
{
    [SerializeField] private GameObject gun;

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
    }
}
