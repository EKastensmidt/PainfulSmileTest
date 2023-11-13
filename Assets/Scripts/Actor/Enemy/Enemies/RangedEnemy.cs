using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RangedEnemy : Enemy
{
    private float shootTimer;
    private Transform shootEmitter;

    public override void Start()
    {
        base.Start();

        shootEmitter = GetComponentInChildren<Transform>();
    }

    public override void MovePosition()
    {
        if(GetDistance() >= Stats.ShootingDistance)
        {
            transform.position += ObstacleAvoidance() * Stats.Speed * Time.deltaTime;
        }
        else if (shootTimer <= 0f)
        {
            ShootProjectile();
            shootTimer = Stats.ShootingCD;
        }

        shootTimer -= Time.deltaTime;
    }

    private void ShootProjectile()
    {
        Vector3 shootDirection = Target.transform.position - shootEmitter.position;

        GameObject shotProjectile = Instantiate(Stats.ProjectilePrefab, shootEmitter.position, Quaternion.identity);
        Rigidbody2D projectileRb = shotProjectile.GetComponent<Rigidbody2D>();
        projectileRb.velocity = shootDirection.normalized * Stats.ProjectileSpeed;

        StartCoroutine(DestroyProjectile(4f, shotProjectile));
    }

    private float GetDistance()
    {
        float dist = Vector2.Distance(transform.position, Target.transform.position);
        return dist;
    }

    IEnumerator DestroyProjectile(float timer, GameObject projectile)
    {
        yield return new WaitForSeconds(timer);

        if (projectile != null)
            Destroy(projectile);
    }
}
