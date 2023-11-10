using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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

        RotateShip();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        MovePosition();
    }

    private void MovePosition()
    {
        Rb.MovePosition(transform.position + GetMoveDirection() * stats.Speed * Time.deltaTime);
    }
    
    private Vector3 GetMoveDirection()
    {
        float vel = rbTarget.velocity.magnitude;
        Vector3 posPrediction = target.transform.position + target.transform.forward * vel * Stats.PredictionTime;
        Vector3 dir = (posPrediction - transform.position).normalized;
        return dir;
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

}
