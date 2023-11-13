using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] GameObject heartPrefab;
    [SerializeField] private Enemy enemy;
    List<HealthHeart> hearts = new List<HealthHeart>();

    private void OnEnable()
    {

        Enemy.OnEnemyTakeDamage += DrawHearts;
        Enemy.OnEnemySpawn += DrawHearts;

    }
    private void OnDisable()
    {
        Enemy.OnEnemyTakeDamage -= DrawHearts;
        Enemy.OnEnemySpawn -= DrawHearts;

    }

    private void Start()
    {
        DrawHearts();

    }

    public void DrawHearts()
    {
        ClearHearts();
        float maxHealthRemainder = enemy.Stats.MaxHealth % 2;
        int heartsToMake = (int)(enemy.Stats.MaxHealth / 2 + maxHealthRemainder);

        for (int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHeart();
        }

        for (int i = 0; i < hearts.Count; i++)
        {
            int heartStatusRemainder = (int)Mathf.Clamp(enemy.Health - (i * 2), 0, 2);
            hearts[i].SetHeartImage((HeartStatus)heartStatusRemainder);
        }
    }

    public void CreateEmptyHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        HealthHeart heartComponent = newHeart.GetComponent<HealthHeart>();
        heartComponent.SetHeartImage(HeartStatus.empty);
        hearts.Add(heartComponent);
    }

    public void ClearHearts()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HealthHeart>();
    }
}
