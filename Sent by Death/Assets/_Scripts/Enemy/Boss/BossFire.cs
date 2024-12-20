using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFire : MonoBehaviour
{
    public enum SpawnerType { Straight, Spin }

    [Header("Bullet")]
    public GameObject bulletPrefab;

    [Header("Spawner")]
    [SerializeField] SpawnerType type;
    public float spin;
    public float fireRate;
    public bool canSpawn = true;

    private float timer;

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (type == SpawnerType.Spin)
        {
            transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + spin);
        }

        if (canSpawn && timer > fireRate)
        {
            Fire();
            timer = 0;
        }
    }

    void Fire()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
