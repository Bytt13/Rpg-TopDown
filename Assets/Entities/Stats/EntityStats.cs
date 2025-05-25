using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour
{

    public float max_hp;
    public float cur_hp;

    public float dmg;
    public float atk_spd;
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

    public void isDead()
    {
        if (cur_hp <= 0)
        {
            Death();
        }
    }
}
