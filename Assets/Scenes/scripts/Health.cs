using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public float maxHealth = 100f;
    public float currentHealth = 100f;

    
    public IDieBehavior onDie;

    
    
    public void damage(float value) {
        currentHealth -= value;
        if (currentHealth <= 0) {
            onDie.die();
        }
    }



}
