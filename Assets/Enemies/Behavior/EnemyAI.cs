using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float chaseRange = 100f;
    GameObject player;
    public Transform target;
    public Vector2 avoidDirection;
    EntityMovement movement;
    EntityStats stats;
    private float avoidTimer = 0f;
    private float avoidTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //Add enitity movement and stats to the enemy
        movement = gameObject.GetComponent<EntityMovement>();
        stats = gameObject.GetComponent<EntityStats>();

        //Set a specific speed for the type of creature
        movement.type_speed = 1.75f;
        player = GameObject.FindGameObjectWithTag("Player");

        //Set the target to the player
        target = player.transform;
        gameObject.GetComponent<Rigidbody2D>();
        //Set the speed of the creature depending on the type of creature
        movement.base_speed = movement.base_speed * movement.type_speed;

        //Set the stats of the enemy
        stats.max_hp = 100f;
        stats.cur_hp = stats.max_hp;
        stats.dmg = 25f;
    }

    // Update is called during time intervals
    void FixedUpdate()
    {
        following();
        stats.isDead();
    }

    // Function to move the enemy towards the player
    void following()
    {
         if (avoidTimer > 0)
        {
            // Está em modo de desvio
            movement.Move(avoidDirection);
            avoidTimer -= Time.fixedDeltaTime;
            return;
        }

        float distance = Vector2.Distance(transform.position, target.position);

        if (distance <= chaseRange)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            movement.Move(direction);
        }
        else
        {
            movement.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EntityStats playerStats = collision.gameObject.GetComponent<EntityStats>();
            if (playerStats != null)
            {
                playerStats.cur_hp -= stats.dmg;
                Debug.Log("Player HP: " + playerStats.cur_hp);
                playerStats.isDead();
            }

            stats.cur_hp -= stats.max_hp + 1;
            stats.isDead();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Vector2 normal = collision.contacts[0].normal;
            int side = Random.value > 0.5f ? 1 : -1;
            avoidDirection = side * Vector2.Perpendicular(normal).normalized;

            avoidTimer = avoidTime;
        }

        
    }

}
