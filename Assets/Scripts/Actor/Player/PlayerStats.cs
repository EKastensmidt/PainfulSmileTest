using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Scriptable Object/Players", order = 0)]

public class PlayerStats : ScriptableObject
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private float rotationSpeed = 4f;

    [SerializeField] private float singleShotCD = 1f;
    [SerializeField] private float tripleShotCD = 2.5f;

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 5f;

    [SerializeField] private List<Sprite> deteriorationSprites;

    public float Speed { get => speed; set => speed = value; }
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public float RotationSpeed { get => rotationSpeed; set => rotationSpeed = value; }
    public float SingleShotCD { get => singleShotCD; set => singleShotCD = value; }
    public float TripleShotCD { get => tripleShotCD; set => tripleShotCD = value; }
    public GameObject ProjectilePrefab { get => projectilePrefab; set => projectilePrefab = value; }
    public float ProjectileSpeed { get => projectileSpeed; set => projectileSpeed = value; }
    public List<Sprite> DeteriorationSprites { get => deteriorationSprites; set => deteriorationSprites = value; }
}
