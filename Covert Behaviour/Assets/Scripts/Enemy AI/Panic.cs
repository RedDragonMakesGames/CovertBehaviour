using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;
public class Panic : Node
{
    public int panicSlow = 3;
    public float panicSpeed = 0.2f;
    private Transform mBody;

    private int count = 0;
    private Vector3 direction = Vector3.zero;

    public Panic(Transform body)
    {
        mBody = body;
    }

    public override NodeState Evaluate()
    {
        if (count++ >= panicSlow)
        {
            count = 0;
            Vector2 direction2d = Random.insideUnitCircle;
            direction = new Vector3(direction2d.x, 0, direction2d.y);
            mBody.LookAt(mBody.position + direction);
        }
        mBody.position += direction * panicSpeed;

        return NodeState.Running;
    }
}
