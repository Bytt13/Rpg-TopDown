using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int currentWave = 1;
    public int enemiesAlive;
    public int factor = 2;
    public float delay = 3f;
    public float spawn_radius = 5f;
    bool isSpawning = false;

    public GameObject enemyPrefab;
    public Vector2 spawnPoint = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    // Update is called once per frame
    void Update()
    {
        //if all enemies are dead, increase the wave count and spawn new enemies
        if (enemiesAlive == 0 && isSpawning == false)
        {
            StartCoroutine(SpawnWave());
        }
    }

    //IEnumerator to handle the spawning of enemies
    IEnumerator SpawnWave()
    {
        isSpawning = true;
        yield return new WaitForSeconds(delay);

        //Check if the wave is already spawning

        int enemiesToSpawn = currentWave * factor;
        enemiesAlive = enemiesToSpawn;

        //Spawn enemies in a circle around the spawn point
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Vector2 spawnPosition = (Vector2)spawnPoint;
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }

        currentWave++;
        isSpawning = false;
    }
    
    public void EnemyDied()
    {
        enemiesAlive--;
    }
}
