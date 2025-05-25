using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float base_speed = 0.00175f;
    float move_speed;
    // Start is called before the first frame update
    void Start()
    {
        // Set the initial position of the player
        
    }

    // Update is called once per frame
    void Update()
    {
        wasdMove();
    }

    // Function to move the player using WASD keys
    void wasdMove()
    {
        // Get the input from WASD keys
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");


        // Move the player using Rigidbody2D
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(x, y) * base_speed);

        // Normalize the input to prevent faster diagonal movement
        if ((x > 0 || x < 0) && (y > 0 || y < 0))
        {
            move_speed = base_speed * 0.66f;
        }
        else
        {
            move_speed = base_speed;
        }

    }
}
