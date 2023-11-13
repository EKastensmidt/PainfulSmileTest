using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Enemy : Actor
{
    [SerializeField] private EnemyStats stats;

    private GameObject target;
    private float health;

    public float Health { get => health; set => health = value; }
    public EnemyStats Stats { get => stats; set => stats = value; }
    public GameObject Target { get => target; set => target = value; }

    public static event Action OnEnemyShipDestroyed;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        if (target == null)
            return;

        MovePosition();
        RotateShip();
    }

    public override void ActorSpawned()
    {
        base.ActorSpawned();

        target = GameObject.FindGameObjectWithTag("Player");
        health = stats.MaxHealth;
    }

    public override void TakeDamage(int damage)
    {
        health -= damage;

        DeteriorateShip();

        if (health <= 0)
        {
            DestroyShip();
        }
    }

    public virtual void DestroyShip()
    {
        OnEnemyShipDestroyed?.Invoke();

        Destroy(gameObject);
    }

    public virtual void MovePosition()
    {
        transform.position += ObstacleAvoidance() * stats.Speed * Time.deltaTime;
    }

    private void RotateShip()
    {
        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize();

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Stats.RotationSpeed * Time.deltaTime);
    }

    protected Vector3 ObstacleAvoidance()
    {
        Collider2D[] obstacles = Physics2D.OverlapCircleAll(transform.position, stats.ObstacleAvoidRadius, stats.AvoidLayerMask);

        Collider2D closestObs = null;
        float closestDistance = float.MaxValue;

        for (int i = 0; i < obstacles.Length; i++)
        {
            Collider2D col = obstacles[i];
            if (closestDistance > Vector2.Distance(transform.position, col.ClosestPoint(transform.position)))
            {
                closestObs = col;
            }
        }
        Vector2 dirToTarget = (target.transform.position - transform.position).normalized;

        if (closestObs != null)
        {
            Vector2 dirObsToNpc = ((Vector2)transform.position - closestObs.ClosestPoint(transform.position));
            dirObsToNpc = dirObsToNpc.normalized * stats.ObstacleAvoidWeight * Mathf.Min(Mathf.Sqrt(stats.ObstacleAvoidRadius), 2);

            dirToTarget += dirObsToNpc;
        }
        return dirToTarget.normalized;
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
