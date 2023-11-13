using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileStats stats;
    
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Actor actor = collision.GetComponent<Actor>();

        if (actor != null)
        {
            actor.TakeDamage(stats.Damage);

            GameObject particles = Instantiate(stats.DamageParticles, new Vector3(transform.position.x,transform.position.y,-1f), Quaternion.identity);
            particles.GetComponent<ParticleSystem>().Play();
        }

        Destroy(gameObject);
    }
}
