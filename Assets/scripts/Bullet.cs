using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        if (HealthBehavior.alive) transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<HealthBehavior>(out HealthBehavior ht))
        {
            ht.Hit(1);
        }
        else if (other.TryGetComponent<Wall>(out Wall w))
        {
            gameObject.SetActive(false);
        }
    }
}
