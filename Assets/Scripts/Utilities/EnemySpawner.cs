using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<Enemy> enemyPrefabs = new List<Enemy>();
    private BoxCollider2D boxCollider;

    private float enemySpawnTimer;
    private float enemySpawnCD;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

        if (PlayerPrefs.HasKey("EnemySpawnTime"))
        {
            enemySpawnCD = PlayerPrefs.GetFloat("EnemySpawnTime");
        }
        else
        {
            enemySpawnCD = 1f;
        }

        Debug.Log(enemySpawnCD);
    }

    private void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if(enemySpawnTimer <= 0f)
        {
            Instantiate(PickRandomEnemy(), PickRandomSpawnPoint(), Quaternion.identity);
            enemySpawnTimer = enemySpawnCD;
        }
        enemySpawnTimer -= Time.deltaTime;
    }

    private Vector2 PickRandomSpawnPoint()
    {
        Bounds bounds = boxCollider.bounds;
        float randomX, randomY;

        if (Random.Range(0, 2) == 0)
        {
            randomX = Random.Range(bounds.min.x, bounds.max.x);
            randomY = (Random.Range(0, 2) == 0) ? bounds.min.y : bounds.max.y;
        }
        else
        {
            randomX = (Random.Range(0, 2) == 0) ? bounds.min.x : bounds.max.x;
            randomY = Random.Range(bounds.min.y, bounds.max.y);
        }

        return new Vector2(randomX, randomY);
    }

    private Enemy PickRandomEnemy()
    {
        int randNum = Random.Range(0, enemyPrefabs.Count);
        return (enemyPrefabs[randNum]);
       
    }
}
