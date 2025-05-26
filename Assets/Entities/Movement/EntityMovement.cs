using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EntityMovement : MonoBehaviour
{
    public float base_speed = 1000f; // Base speed of the entity
    public float type_speed; // Speed multiplier based on entity type (e.g., player, enemy)
    protected Rigidbody2D rb; // Rigidbody2D component for physics interactions

    private Vector2 moveDirection;
    // Start is called before the first frame update
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //Function to set the movement direction
    public virtual void Move(Vector2 direction)
    {
        rb.AddForce(direction.normalized * base_speed * type_speed * Time.deltaTime);
    }

    //Function to stop the movement
    public virtual void Stop()
    {
        rb.AddForce(Vector2.zero);
    }

}
