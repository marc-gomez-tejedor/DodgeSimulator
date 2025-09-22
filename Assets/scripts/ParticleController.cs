using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private ParticleSystem particles;

    void Start()
    {
        // Get the Particle System component on this GameObject
        particles = GetComponent<ParticleSystem>();
    }
    public void MoveAndPlay(Vector3 targetPosition)
    {
        gameObject.transform.position = targetPosition;
        particles.Play();
    }
}
