using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class Patrol : Node
{
    public float reachedWaypointDistance = 0.6f;

    private Vector3[] mWaypoints;
    private float mSpeed;

    private Transform mBody;

    private int mCurrentWaypoint = 0;

    public Patrol(PatrolObject parameters, Transform body)
    {
        mWaypoints = parameters.waypoints;
        mSpeed = parameters.speed;
        mBody = body;
    }

    public override NodeState Evaluate()
    {
        if (CheckIfAtWaypoint())
        {
            if (mCurrentWaypoint + 1 >= mWaypoints.Length)   //Loop if we've got to the end of the waypoints
                mCurrentWaypoint = 0;
            else
                mCurrentWaypoint++;
        }

        //Move to the next waypoint
        mBody.LookAt(mWaypoints[mCurrentWaypoint]);
        mBody.position += (mWaypoints[mCurrentWaypoint] - mBody.position).normalized * mSpeed;

        return NodeState.Running;
    }

    private bool CheckIfAtWaypoint()
    {
        if ((mBody.position - mWaypoints[mCurrentWaypoint]).magnitude < reachedWaypointDistance)
            return true;
        else
            return false;
    }
}
