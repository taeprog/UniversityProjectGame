using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopterDie : IDieBehavior
{
    private bool dead = false;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public override void die()
    {
        dead = true;
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.None;
        rb.AddTorque(Random.Range(0.0f, 30f), Random.Range(0.0f, 30f), Random.Range(0.0f, 30f));

    }

    public void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (dead 
            && !collision.gameObject.tag.Equals("Mortal")
            && !collision.gameObject.tag.Equals("Bullet")
            && !collision.gameObject.tag.Equals("Player")) Destroy(this.gameObject);
    }

}
