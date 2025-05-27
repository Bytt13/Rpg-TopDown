using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public float damage; // Damage dealt by the projectile
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EntityStats enemy = collision.gameObject.GetComponent<EntityStats>();
            enemy.cur_hp -= damage; // Apply damage to the enemy's current HP
            enemy.killed = true; // Mark the enemy as killed
            enemy.isDead(); // Check if the enemy is dead
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(this.gameObject);
        }
    }
}
