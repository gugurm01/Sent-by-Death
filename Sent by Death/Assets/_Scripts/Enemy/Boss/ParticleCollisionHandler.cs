using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollisionHandler : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        PlayerLife life = GetComponent<PlayerLife>();
        life.TakeDamage(1);
    }
}
