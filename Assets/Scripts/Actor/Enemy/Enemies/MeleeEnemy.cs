using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(Stats.Damage);

            GameObject DeathExplotionObject = Instantiate(Stats.Explosion, transform.position, Quaternion.identity);
            Destroy(DeathExplotionObject, 0.2f);

            DestroyShip();
        }
    }

}
