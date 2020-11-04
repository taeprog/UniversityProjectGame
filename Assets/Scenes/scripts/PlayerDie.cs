using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : IDieBehavior
{
    private bool dead = false;

    private void Start()
    {
       
    }
    public override void die()
    {
        dead = true;
        
    }

    public void Update()
    {
        if (dead) {
            StaticUIElements.instance.deadWindow.show();
        }
    }

}
