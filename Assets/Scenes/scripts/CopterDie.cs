using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopterDie : IDieBehavior
{
    private bool dead = false;

    public override void die()
    {
        Debug.Log("Dead " + this.tag);
        dead = true;
    }

    public void Update()
    {
        if (dead) Destroy(this.gameObject);
    }

}
