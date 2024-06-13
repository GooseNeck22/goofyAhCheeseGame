using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] movePoints; // Define move points in the spawner
    [SerializeField] private float interval = 3f;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            timer = 0f;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        // Instantiate the enemy
        GameObject spawnedEnemy = Instantiate(enemyPrefab, transform.position, transform.rotation);

        // Get the EnemyMovement script on the spawned enemy
        EnemyMovement enemyMovement = spawnedEnemy.GetComponent<EnemyMovement>();

        // Check if the spawned enemy has the EnemyMovement script
        if (enemyMovement != null)
        {
            // Assign the movePoints array from the spawner to the enemy's movement script
            enemyMovement.movePoints = movePoints;
        }
    }
}