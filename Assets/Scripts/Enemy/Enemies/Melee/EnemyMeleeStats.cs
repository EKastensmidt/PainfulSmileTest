using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyMelee", menuName = "Scriptable Object/Enemies/EnemyMelee", order = 0)]
public class EnemyMeleeStats : EnemyStats
{
    [SerializeField] float obstacleAvoidRadius = 1f;
    [SerializeField] float obstacleAvoidWeight = 0.8f;
    [SerializeField] private LayerMask avoidLayerMask;

    public float ObstacleAvoidRadius { get => obstacleAvoidRadius; set => obstacleAvoidRadius = value; }
    public float ObstacleAvoidWeight { get => obstacleAvoidWeight; set => obstacleAvoidWeight = value; }
    public LayerMask AvoidLayerMask { get => avoidLayerMask; set => avoidLayerMask = value; }
}
