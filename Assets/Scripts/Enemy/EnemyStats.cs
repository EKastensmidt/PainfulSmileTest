using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable Object/Enemies", order = 1)]

public class EnemyStats : ScriptableObject
{
    [SerializeField] private int maxHealth;
    [SerializeField] private float speed;
    [SerializeField] private int damage; //Only for meleeShip
    [SerializeField] private float rotationSpeed;

    [SerializeField] float obstacleAvoidRadius = 1f;
    [SerializeField] float obstacleAvoidWeight = 0.8f;
    [SerializeField] private LayerMask avoidLayerMask;

    public int MaxHealth { get => maxHealth; }
    public float Speed { get => speed; }
    public int Damage { get => damage; }
    public float RotationSpeed { get => rotationSpeed; }

    public float ObstacleAvoidRadius { get => obstacleAvoidRadius; set => obstacleAvoidRadius = value; }
    public float ObstacleAvoidWeight { get => obstacleAvoidWeight; set => obstacleAvoidWeight = value; }
    public LayerMask AvoidLayerMask { get => avoidLayerMask; set => avoidLayerMask = value; }
}
