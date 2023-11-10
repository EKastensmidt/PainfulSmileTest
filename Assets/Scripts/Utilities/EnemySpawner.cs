using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<Enemy> enemyPrefabs = new List<Enemy>();
    private BoxCollider2D boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

        for (int i = 0; i < 10; i++)
        {
            Vector2 randomPoint = PickRandomSpawnPoint();
            Instantiate(enemyPrefabs[0], randomPoint, Quaternion.identity);
        }
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
}
