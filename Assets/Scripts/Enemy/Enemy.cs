using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected GameObject target;
    private Collider2D col;
    private Rigidbody2D rb;
    private float health;

    public Collider2D Col { get => col; set => col = value; }
    public Rigidbody2D Rb { get => rb; set => rb = value; }
    public float Health { get => health; set => health = value; }

    public virtual void Start()
    {
        EnemySpawned();
    }

    public virtual void Update()
    {
        
    }

    public virtual void FixedUpdate()
    {

    }

    private void EnemySpawned()
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("PlayerShip");
    }

    public virtual void TakeDamage(float damage)
    {

    }

    public virtual void DestroyShip()
    {

    }
}
