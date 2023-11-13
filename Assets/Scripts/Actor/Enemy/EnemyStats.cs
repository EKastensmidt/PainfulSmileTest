using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable Object/Enemies", order = 1)]

public class EnemyStats : ScriptableObject
{
    [SerializeField] private int maxHealth;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

    [SerializeField] float obstacleAvoidRadius = 1f;
    [SerializeField] float obstacleAvoidWeight = 0.8f;
    [SerializeField] private LayerMask avoidLayerMask;
    [SerializeField] private List<Sprite> deteriorationSprites;

    //Only for MeleeShip
    [Header("MeleeStats")]
    [SerializeField] private int damage;
    [SerializeField] private GameObject explosion;

    //Only for RangedShip
    [Header("RangedStats")]
    [SerializeField] private float shootingDistance; 
    [SerializeField] private float shootingCD; 
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed;

    public int MaxHealth { get => maxHealth; }
    public float Speed { get => speed; }
    public int Damage { get => damage; }
    public float RotationSpeed { get => rotationSpeed; }

    public float ObstacleAvoidRadius { get => obstacleAvoidRadius; set => obstacleAvoidRadius = value; }
    public float ObstacleAvoidWeight { get => obstacleAvoidWeight; set => obstacleAvoidWeight = value; }
    public LayerMask AvoidLayerMask { get => avoidLayerMask; set => avoidLayerMask = value; }
    public float ShootingDistance { get => shootingDistance; set => shootingDistance = value; }
    public float ShootingCD { get => shootingCD; set => shootingCD = value; }
    public GameObject ProjectilePrefab { get => projectilePrefab; set => projectilePrefab = value; }
    public float ProjectileSpeed { get => projectileSpeed; set => projectileSpeed = value; }
    public GameObject Explosion { get => explosion; set => explosion = value; }
    public List<Sprite> DeteriorationSprites { get => deteriorationSprites; set => deteriorationSprites = value; }
}
