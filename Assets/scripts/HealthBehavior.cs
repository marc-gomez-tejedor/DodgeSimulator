using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthBehavior : MonoBehaviour
{
    public static bool alive = true;
    public UnityEvent onDie;
    public int health;
    private Animator animator;
    void Start()
    {
        alive = true;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (health <= 0)
        {
            animator.SetTrigger("die");
            alive = false;
            onDie.Invoke();
        }
                
    }
    public void Hit(int dmg)
    {
        health -= dmg;
    }
    public void Die()
    {
        Time.timeScale = 0;
    }
    public void Revive()
    {
        Time.timeScale = 1;
        health = 1;
    }
    public void Kill()
    {
        health = 0;
    }
}
