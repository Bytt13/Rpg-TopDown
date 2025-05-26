using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject projectile; // Reference to the projectile prefab
    float cooldown; // Cooldown timer for the attack
    bool can_attack = true; // Flag to check if the player can attack
    public EntityStats stats; // Reference to the EntityStats script to get the damage value
    // Start is called before the first frame update
    void Start()
    {
        stats = gameObject.GetComponent<EntityStats>();
        stats.atk_spd = 0.25f; // Set the attack speed, can be adjusted as needed
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && can_attack == true) // Left mouse button
        {
            Shoot();
        }

        Cooldown();
    }

    //Funciton to shoot the bullets
    void Shoot()
    {
        GameObject projectile_instance = Instantiate(projectile, transform.position, Quaternion.identity);
        Vector2 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouse_position - (Vector2)transform.position).normalized;
        projectile_instance.GetComponent<Rigidbody2D>().AddForce(direction * 10f, ForceMode2D.Impulse);
        // Make sure the projectile has a Rigidbody2D component for physics interactions and movement following your mouse

        projectile_instance.GetComponent<ProjectileDamage>().damage = stats.dmg; // Set the damage value for the projectile
        can_attack = false;
        cooldown = 0f;
    }

    //Function to handle cooldown
    void Cooldown()
    {
        float cd = stats.atk_spd;
        if (cooldown > cd && can_attack == false)
        {
            can_attack = true;
        }
        else
        {
            cooldown += Time.deltaTime;
        }
    }
}
