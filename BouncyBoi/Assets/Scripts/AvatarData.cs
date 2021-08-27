using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newAvatarData", menuName = "ScriptableObjects/AvatarData")]
public class AvatarData : ScriptableObject
{
    [Header("Move State")]
    public float moveSpeed = 10f;
}
