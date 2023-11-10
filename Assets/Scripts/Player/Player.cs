using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;
    private Rigidbody2D rb;
    private Collider2D col;
    private float health;

    [SerializeField] protected Transform singleShotEmitter;
    [SerializeField] protected Transform tripleShotEmitter;
    [SerializeField] protected Transform tripleShotEmitter2;

    public PlayerStats Stats { get => stats; set => stats = value; }
    public Rigidbody2D Rb { get => rb; }
    public Collider2D Col { get => col; }
    public float Health { get => health; set => health = value; }

    public virtual void Start()
    {
        PlayerSpawned();
    }

    public virtual void Update()
    {

    }

    private void PlayerSpawned()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        health = stats.MaxHealth;
    }

    public virtual void TakeDamage(int amount)
    {
        health -= amount;

        //if (health <= 0)
        //{
        //    //Die
        //}
    }
}
