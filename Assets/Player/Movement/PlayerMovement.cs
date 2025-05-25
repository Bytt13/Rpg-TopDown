using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    EntityMovement movement;
    EntityStats stats;

    // Start is called before the first frame update
    void Start()
    {
        //Add enitity movement and stats to the player
        movement = gameObject.GetComponent<EntityMovement>();
        stats = gameObject.GetComponent<EntityStats>();
        //Set a specific speed for the type of creature
        movement.type_speed = 2.1f;
        //Set the speed of the creature depending on the type of creature
        movement.base_speed = movement.base_speed * movement.type_speed;

        //Set the stats of the player
        stats.max_hp = 100f;
        stats.cur_hp = stats.max_hp;
        stats.dmg = 10f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        wasdMove();
    }

    // Function to move the player using WASD keys
    void wasdMove()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movement.Move(input);
    }
}
