using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copter : MonoBehaviour
{
    private int id;
    public float forwardDetectRange = 70f;
    public float detectRadius = 50f;
    public float speed = 50f;
    public float stopDistance = 20f;
    
    Transform player;
    Rigidbody rb;
    Health health;
    Shooting shooting;
    private bool isAttacking = false;
    private float lastShoot;
    void Start()
    {
        id = (int)(transform.position.x + transform.position.y + transform.position.z);
        onLoad();
        rb = GetComponent<Rigidbody>();
        player = SceneManager.instance.player.transform;
        health = GetComponent<Health>();
        shooting = GetComponent<Shooting>();
        lastShoot = Time.time;
    }

    public int getId() { return id; }


    private void onLoad() {
        if (SaveLoadSystem.gameState != null) {
            if (Array.Find(SaveLoadSystem.gameState.Drones, (a) => a.id == id) == null) {
                Destroy(this.gameObject);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (health.currentHealth <= 0) {
            return;
        }
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
                isAttacking = false; 
                rb.velocity = rb.transform.forward * speed;
            }
            else
            {
                isAttacking = true;
                rb.velocity = new Vector3(0f, 0f, 0f);
            }
        }
        if (isAttacking) {
            attack();
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

    private void attack() {
        if (Time.time - lastShoot >= 1) {
            lastShoot = Time.time;
            shooting.Shoot();
        }
    }
    
}
