using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;
public class MoveToPlayer : Node
{
    public float reachedWaypointDistance = 2.0f;

    private float mSpeed;
    private GameObject mPlayer;
    private Transform mBody;

    public MoveToPlayer(PatrolObject path, Transform body)
    {
        mSpeed = path.chaseSpeed;
        mBody = body;
        mPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    public override NodeState Evaluate()
    {
        if (CheckIfAtWaypoint())
            return NodeState.NodeComplete;
        else
        {
            //Move to the player
            mBody.LookAt(mPlayer.transform.position);
            mBody.position += (mPlayer.transform.position - mBody.position).normalized * mSpeed;
            return NodeState.Running;
        }
    }

    private bool CheckIfAtWaypoint()
    {
        if ((mBody.position - mPlayer.transform.position).magnitude < reachedWaypointDistance)
            return true;
        else
            return false;
    }
}
