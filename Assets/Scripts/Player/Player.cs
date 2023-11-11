using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : Actor
{
    [SerializeField] private PlayerStats stats;
    private float health;

    [SerializeField] protected Transform singleShotEmitter;
    [SerializeField] protected Transform tripleShotEmitter;
    [SerializeField] protected Transform tripleShotEmitter2;

    public PlayerStats Stats { get => stats; set => stats = value; }
    public float Health { get => health; set => health = value; }

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
    }

    public override void TakeDamage(int amount)
    {
        health -= amount;

        //if (health <= 0)
        //{
        //    //Die
        //}
    }
}
