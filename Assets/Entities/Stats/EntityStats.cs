using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class EntityStats : MonoBehaviour
{

    public float max_hp; // Maximum health of the entity
    public float cur_hp; // Current health of the entity
    public float dmg; // Damage dealt by the entity
    public float atk_spd; // Attack speed of the entity
    public bool is_alive = true; // Flag to check if the entity is alive
    public bool killed = false; // Flag to check if the entity was killed   
    // Start is called before the first frame update
    void Start()
    {
        is_alive = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Funtion to DIE
    public void Death()
    {
        Destroy(gameObject);
    }

    //Function to check if the entity is dead
    public void isDead()
    {
        if (cur_hp <= 0 && is_alive)
        {
            is_alive = false; // Reset the alive status

            if (!CompareTag("Player") && killed) // If the entity is not the player and was killed
            {
                HudManager hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HudManager>();
                hud.AddKill(); // Increment the kill count in the HUD
            }

            Death(); 
        }
    }
}
