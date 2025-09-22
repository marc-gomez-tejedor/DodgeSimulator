using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public GameObject bulletPrefab;  // Reference to the bullet prefab
    public float shootingInterval = 2.0f;  // Time interval between possible shots in seconds
    public float chanceToShoot = 0.2f;  // Chance to shoot when possible, between 0 and 1
    private float timeSinceLastShot = 0.0f;  // Time since the last shot was fired
    private Animator animator;
    public AudioClip bulletAudio;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.y = 0;
        
        transform.rotation = Quaternion.LookRotation(directionToPlayer);

        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= shootingInterval)
        {
            float roll = Random.Range(0f, 1f);

            if (roll <= chanceToShoot)
            {
                CastShot();
            }

            timeSinceLastShot = 0.0f;
        }
    }
    void CastShot()
    {
        animator.SetTrigger("shoot");
    }
    public void Shoot()
    {
        // Instantiate a bullet and set its initial position and rotation to be the same as the enemy
        GameObject bullet = Instantiate(bulletPrefab, new Vector3(0,0.6f,0) + transform.position + transform.forward, transform.rotation);
        AudioManager.instance.Play("bullet");

        // The bullet will automatically move forward based on its Bullet script
    }
}
