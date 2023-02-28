using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;
public class CheckIfPanicking : Node
{

    public override NodeState Evaluate()
    {
        bool isPanicking = (bool)GetData("panic");
        if (isPanicking)
            return NodeState.NodeComplete;
        else
            return NodeState.Stop;
    }
}
