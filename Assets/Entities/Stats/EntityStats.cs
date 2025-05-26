using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour
{

    public float max_hp; // Maximum health of the entity
    public float cur_hp; // Current health of the entity
    public float dmg; // Damage dealt by the entity
    public float atk_spd; // Attack speed of the entity
    // Start is called before the first frame update
    void Start()
    {

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
        if (cur_hp <= 0)
        {
            Death();
        }
    }
}
