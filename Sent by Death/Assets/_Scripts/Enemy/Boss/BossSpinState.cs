using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpinState : MonoBehaviour
{
    public float rotationSpeed = 100f;
    private int direction = 1;
    public GameObject[] straightSpawners;
    public GameObject straightSpawnersParent;
    public GameObject rotateSpawnersParent;

    public bool isSweeping = false;
    public float sweepSpeed = 500f;
    public float returnSpeed = 100f;
    public float maxAngle = 45f;

    private bool sweepingOut = true;
    private float currentAngle = 0f;
    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    void FixedUpdate()
    {
        straightSpawners = GameObject.FindGameObjectsWithTag("NPC");

        if (isSweeping)
        {
            ContinuousSweep();
        }
        else
        {
            transform.Rotate(0, 0, direction * rotationSpeed * Time.deltaTime);
        }

        if (straightSpawners.Length == 0)
        {
            straightSpawnersParent.SetActive(false);
            rotateSpawnersParent.SetActive(true);
        }
    }

    public void SwitchDirection()
    {
        direction *= -1;
    }

    private void ContinuousSweep()
    {
        float speed = sweepingOut ? sweepSpeed : returnSpeed;
        float step = speed * Time.deltaTime;

        currentAngle += sweepingOut ? step : -step;

        if (sweepingOut && currentAngle >= maxAngle)
        {
            sweepingOut = false;
        }
        else if (!sweepingOut && currentAngle <= 0f)
        {
            sweepingOut = true;
        }

        transform.rotation = initialRotation * Quaternion.Euler(0, 0, currentAngle);
    }
}
