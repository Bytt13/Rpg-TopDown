using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EntityMovement : MonoBehaviour
{
    public float base_speed = 1000f;
    public float type_speed;
    protected Rigidbody2D rb;

    private Vector2 moveDirection;
    // Start is called before the first frame update
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Move(Vector2 direction)
    {
        rb.AddForce(direction.normalized * base_speed * type_speed * Time.deltaTime);
    }

    public virtual void Stop()
    {
        rb.AddForce(Vector2.zero);
    }

}
