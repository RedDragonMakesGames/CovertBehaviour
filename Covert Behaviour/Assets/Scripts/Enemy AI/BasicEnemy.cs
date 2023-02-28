using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;
public class BasicEnemy : BehaviourTree.Tree
{
    public PatrolObject path;
    public Collider sight;

    public Material panicked;
    public Material normal;

    public int flashSpeed = 5;
    private int flashCount = 0;

    protected override Node SetUpTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckIfPanicking(),
                new Panic(transform)
            }),
            new Sequence(new List<Node>
            {
                new CheckIfPlayerSeen(sight),
                new MoveToPlayer(path, transform)
            }),
            new Patrol(path, transform)
        });

        root.SetData("panic", false);

        //Sort out renderer
        Renderer[] surfaces = GetComponentsInChildren<Renderer>();
        foreach (Renderer surface in surfaces)
        {
            surface.material = normal;
        }

        return root;
    }

    public void SetPanicking(bool b)
    {
        mRoot.SetData("panic", b);
        if (!b)
        {
            Renderer[] surfaces = GetComponentsInChildren<Renderer>();
            foreach (Renderer surface in surfaces)
            {
                surface.material = normal;
            }
        }
    }
    
    new private void FixedUpdate()
    {
        base.FixedUpdate();
        if (mRoot == null)
            return;
        if ((bool)mRoot.GetData("panic"))
        {
            flashCount++;
            if (flashCount > flashSpeed * 2)
            {
                flashCount = 0;
                Renderer[] surfaces = GetComponentsInChildren<Renderer>();
                foreach (Renderer surface in surfaces)
                {
                    surface.material = normal;
                }
            }
            else if (flashCount == flashSpeed)
            {
                Renderer[] surfaces = GetComponentsInChildren<Renderer>();
                foreach (Renderer surface in surfaces)
                {
                    surface.material = panicked;
                }
            }
        }
    }
}
