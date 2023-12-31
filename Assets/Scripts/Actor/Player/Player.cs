using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Player : Actor
{
    [SerializeField] private PlayerStats stats;
    private float health;

    [SerializeField] protected Transform singleShotEmitter;
    [SerializeField] protected Transform tripleShotEmitter;
    [SerializeField] protected Transform tripleShotEmitter2;

    public PlayerStats Stats { get => stats; set => stats = value; }
    public float Health { get => health; set => health = value; }

    public static event Action OnGameOver;
    public static event Action OnPlayerTakeDamage;
    public static event Action OnPlayerSpawn;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void ActorSpawned()
    {
        base.ActorSpawned();

        health = stats.MaxHealth;
        OnPlayerSpawn?.Invoke();
    }

    public override void TakeDamage(int amount)
    {

        health -= amount;

        OnPlayerTakeDamage?.Invoke();
        DeteriorateShip();

        if (health <= 0)
        {
            OnGameOver?.Invoke();
            Destroy(gameObject);
        }
    }

    private void DeteriorateShip()
    {
        if (health >= stats.MaxHealth / 3)
        {
            SpriteRenderer.sprite = stats.DeteriorationSprites[0];
        }
        else if (health < stats.MaxHealth / 3)
        {
            SpriteRenderer.sprite = stats.DeteriorationSprites[1];
        }
    }
}
