using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticlesOnCollision : MonoBehaviour
{
    private ParticleSystem particle;

    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

    void OnParticleCollision(GameObject other)
    {
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particle.main.maxParticles];
        int numParticlesAlive = particle.GetParticles(particles);

        for (int i = 0; i < numParticlesAlive; i++)
        {
            if (other.CompareTag("Player"))
            {
                particles[i].remainingLifetime = 0;
            }
        }

        particle.SetParticles(particles, numParticlesAlive);
    }
}
