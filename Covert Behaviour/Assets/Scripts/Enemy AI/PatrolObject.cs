using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PatrolObject", order = 1)]
public class PatrolObject : ScriptableObject
{
    public Vector3[] waypoints;
    public float speed;
    public float chaseSpeed;
}
