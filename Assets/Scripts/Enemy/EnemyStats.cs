using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable Object/Enemies", order = 1)]

public class EnemyStats : ScriptableObject
{
    [SerializeField] private int maxHealth;
    [SerializeField] private float speed;
    [SerializeField] private int damage;

    public int MaxHealth { get => maxHealth; }
    public float Speed { get => speed; }
    public int Damage { get => damage; }
}
