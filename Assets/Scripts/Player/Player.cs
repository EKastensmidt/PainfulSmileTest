using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;
    private Rigidbody2D rb;
    private Collider2D col;
    private Animator animator;
    private float health;

    public PlayerStats Stats { get => stats; set => stats = value; }
    public Rigidbody2D Rb { get => rb; }
    public Collider2D Col { get => col; }
    public Animator Animator { get => animator; }
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
        animator = GetComponentInChildren<Animator>();

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
