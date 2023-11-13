using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] GameObject heartPrefab;
    [SerializeField] private Player player;
    List<HealthHeart> hearts = new List<HealthHeart>();

    private void OnEnable()
    {
        Player.OnPlayerTakeDamage += DrawHearts;
        Player.OnPlayerSpawn += DrawHearts;

    }
    private void OnDisable()
    {
        Player.OnPlayerTakeDamage -= DrawHearts;
        Player.OnPlayerSpawn += DrawHearts;
    }

    private void Start()
    {
        DrawHearts();

    }

    public void DrawHearts()
    {
        ClearHearts();
        float maxHealthRemainder = player.Stats.MaxHealth % 2;
        int heartsToMake = (int)(player.Stats.MaxHealth / 2 + maxHealthRemainder);

        for (int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHeart();
        }

        for (int i = 0;i < hearts.Count; i++) 
        {
            int heartStatusRemainder = (int)Mathf.Clamp(player.Health - (i * 2), 0, 2);
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
        hearts = new List<HealthHeart> ();
    }

}
