using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public Slider hp_bar; // Reference to the health bar slider
    EntityStats stats; // Reference to the EntityStats script to get the player's health
    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<EntityStats>();
        // Ensure the health bar is initialized with the player's current health
    }

    // Update is called once per frame
    void Update()
    {
        // Continuously update the health bar to reflect the player's current health
        Health();
    }

    // Function to update the health bar based on the player's current health
    public void Health()
    {
        hp_bar.maxValue = stats.max_hp;
        hp_bar.value = stats.cur_hp;
    }
}
