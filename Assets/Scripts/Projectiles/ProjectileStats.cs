using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "Scriptable Object/Porjectile", order = 2)]

public class ProjectileStats : ScriptableObject
{
    [SerializeField] private int damage = 25;
    [SerializeField] private GameObject damageParticles;

    public int Damage { get => damage; set => damage = value; }
    public GameObject DamageParticles { get => damageParticles; set => damageParticles = value; }
}
