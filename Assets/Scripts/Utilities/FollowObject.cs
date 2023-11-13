using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] private Transform objectToFollow;
    [SerializeField] private Vector2 offset;
    void Update()
    {
        if (objectToFollow == null) return;
    
        transform.position = new Vector2(objectToFollow.position.x + offset.x, objectToFollow.position.y + offset.y);
    }
}
