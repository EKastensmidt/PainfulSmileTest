using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    private Collider2D col;
    private Rigidbody2D rb;

    public Collider2D Col { get => col; set => col = value; }
    public Rigidbody2D Rb { get => rb; set => rb = value; }

    public virtual void Start()
    {
        ActorSpawned();
    }

    public virtual void Update()
    {
        
    }

    public virtual void ActorSpawned()
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void TakeDamage(int damage)
    {

    }
}
