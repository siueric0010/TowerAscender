using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    private const int MAX_ENEMIES_ON_INTERMEDIATE = 9;
    private const float NECRO_SPAWN_RATE = 7.0f;
    private const float BOSS_OFFSET = 2.0f;
    private const float INTERMEDIATE_OFFSET = 10.0f;
    private float nextSpawnTime;
    bool constantSpawning = false;
    private void OnLevelWasLoaded(int level) {
        // Intermediate Level
        // Debug.Log("Level: " + level);
        if(level == 2) {
            int enemy_count = (int)Mathf.Floor(Random.Range(level * PlayerController.floorsCleared, MAX_ENEMIES_ON_INTERMEDIATE));
            for (int i = 0; i < enemy_count; i++) {
                SpawnRandomEnemy(false);
            }
        // Boss Level
        } else if (level == 3) {
            constantSpawning = true;
            nextSpawnTime = Time.time + NECRO_SPAWN_RATE;
            EnemyController.seen = true;
        }
    }

    private void Update() {
        if(constantSpawning && Time.time > nextSpawnTime) {
            nextSpawnTime = Time.time + NECRO_SPAWN_RATE;
            SpawnRandomEnemy(true);
        }
    }

    private void SpawnRandomEnemy(bool isBoss) {
        int randomIndex = (int)Mathf.Floor(Random.Range(0, enemies.Length));
        float posOffset = isBoss ? BOSS_OFFSET : INTERMEDIATE_OFFSET;
        Vector3 spawnPos = new Vector3(Random.Range(-posOffset, posOffset), 0, Random.Range(-posOffset, posOffset));
        spawnPos += transform.position;
        Instantiate(enemies[randomIndex], spawnPos, transform.rotation);
    }
}
