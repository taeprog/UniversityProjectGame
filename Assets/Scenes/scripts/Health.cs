using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100f;
    
    public IDieBehavior onDie;

    
    
    public void damage(float value) {
        health -= value;
        if (health <= 0) {
            onDie.die();
        }
    }



}
