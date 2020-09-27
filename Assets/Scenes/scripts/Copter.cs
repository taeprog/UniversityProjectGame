using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copter : MonoBehaviour
{

    public float forwardDetectRange = 70f;
    public float detectRadius = 50f;
    public float speed = 50f;
    public float stopDistance = 20f;
    
    Transform player;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        bool playerInRange;
        if (looksOnPlayer())
        {
            playerInRange = isPlayerInRange(forwardDetectRange);
        }
        else {
            playerInRange = isPlayerInRange(detectRadius);
        }
        if (playerInRange)
        {
            rb.transform.LookAt(player, player.up);
            if (getRangeToPlayer() > stopDistance)
            {
                //Vector3 movement = Vector3.MoveTowards(rb.position, player.position, Time.fixedDeltaTime * speed);
                rb.velocity = rb.transform.forward * speed;
            }
            else
            {
                rb.velocity = new Vector3(0f, 0f, 0f);
            }
        }
       
        
        
    }

    private bool looksOnPlayer()
    {
        Vector3 directionToPlayer = (player.position - rb.position).normalized;
        float directionProdiction = Vector3.Dot(directionToPlayer, rb.transform.forward);

        return directionProdiction > 0.9f;
    }

    private bool isPlayerInRange(float range) {
        return getRangeToPlayer() <= range;
    }

    private float getRangeToPlayer() {
        return Vector3.Distance(player.position, rb.transform.position);
    }

    
}
