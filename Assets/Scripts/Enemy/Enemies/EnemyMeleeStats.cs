using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyMelee", menuName = "Scriptable Object/Enemies/EnemyMelee", order = 0)]
public class EnemyMeleeStats : EnemyStats
{
    [SerializeField] private float predictionTime = 1f;

    public float PredictionTime { get => predictionTime; set => predictionTime = value; }
}
