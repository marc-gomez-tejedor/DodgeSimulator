using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOffCollider : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<HealthBehavior>(out HealthBehavior ht))
        {
            ht.Kill();
        }
    }
}
