using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] private EnemyMeleeStats stats;

    public EnemyMeleeStats Stats { get => stats; set => stats = value; }

    private Rigidbody2D rbTarget;
    
    public override void Start()
    {
        base.Start();

        Health = stats.MaxHealth;
        rbTarget = target.GetComponent<Rigidbody2D>();
    }

    public override void Update()
    {
        base.Update();

        MovePosition();
        RotateShip();
    }

    private void MovePosition()
    {
        transform.position += ObstacleAvoidance() * stats.Speed * Time.deltaTime;
    }
    
    private void RotateShip()
    {
        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize();

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, stats.RotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(stats.Damage);
            DestroyShip();
        }
    }

    public override void DestroyShip()
    {
        //Explotion animation spawn
        Destroy(gameObject);
    }

    public Vector3 ObstacleAvoidance()
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

}
