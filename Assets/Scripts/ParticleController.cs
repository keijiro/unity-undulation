using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour
{
    float emissionRate;
    float startSpeed;
    ParticleSystem.Particle[] particles;

    void Start ()
    {
        emissionRate = particleSystem.emissionRate;
        startSpeed = particleSystem.startSpeed;
        particles = new ParticleSystem.Particle[particleSystem.maxParticles];
    }
    
    void Update ()
    {
        var currentSpeed = RoadMaker.instance.speed;
        var ratio = currentSpeed / startSpeed;
        var speed = startSpeed * ratio;

        particleSystem.emissionRate = emissionRate * ratio;
        particleSystem.startSpeed = speed;

        var particleCount = particleSystem.GetParticles (particles);

        for (var i = 0; i < particleCount; i++)
        {
            var v = particles[i].velocity;
            v.z = -speed;
            particles[i].velocity = v;
        }

        particleSystem.SetParticles (particles, particleCount);
    }
}
