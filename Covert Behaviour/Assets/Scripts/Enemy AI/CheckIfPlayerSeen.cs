using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;
public class CheckIfPlayerSeen : Node
{
    private Collider mFov;
    private GameObject player;

    public CheckIfPlayerSeen(Collider fov)
    {
        mFov = fov;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override NodeState Evaluate()
    {
        Collider[] playerOverlap = Physics.OverlapSphere(player.transform.position, player.GetComponent<SphereCollider>().radius);
        foreach (Collider col in playerOverlap)
        {
            if (col == mFov)    //If the player's colider is overlapping us
            {
                //Make sure we also have LOS
                if (Physics.Raycast(mFov.transform.parent.transform.position, player.transform.position - mFov.transform.parent.transform.position, out RaycastHit hit))
                {
                    if (hit.collider.gameObject == player)
                        return NodeState.NodeComplete;
                }
            }
                
        }
        return NodeState.Stop;
    }
}
