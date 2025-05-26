using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lama : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Function to cut te speed of the player in half when they enter the trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EntityMovement mover = collision.gameObject.GetComponent<EntityMovement>();
        if (mover != null)
        {
            mover.base_speed /= 2;
        }
    }

    //Function to restore the speed of the player when they exit the trigger
    private void OnTriggerExit2D(Collider2D collision)
    {
        EntityMovement mover = collision.gameObject.GetComponent<EntityMovement>();
        if (mover != null)
        {
            mover.base_speed *= 2;
        }
    }
}
