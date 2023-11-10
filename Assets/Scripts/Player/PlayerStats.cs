using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Scriptable Object/Players", order = 0)]

public class PlayerStats : ScriptableObject
{
    [SerializeField] private float speed = 4;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private float jumpForce = 4;

    public float Speed { get => speed; set => speed = value; }
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public float JumpForce { get => jumpForce; set => jumpForce = value; }
}
