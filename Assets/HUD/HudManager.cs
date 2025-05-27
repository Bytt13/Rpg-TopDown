using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public Slider hp_bar; // Reference to the health bar slider
    public Text kills_text;
    public int kills;
    EntityStats stats; // Reference to the EntityStats script to get the player's health
    EntityStats enemy_stats;
    // Start is called before the first frame update
    void Start()
    {
        enemy_stats = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EntityStats>();
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<EntityStats>();
        kills_text.text = "Kills: " + kills.ToString();
        // Ensure the health bar is initialized with the player's current health and kills text is right
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

    public void AddKill()
    {
        kills++; // Increment the kill count
        kills_text.text = "Kills: " + kills.ToString(); // Update the kills text in the HUD
    }
}
