using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform bulletSpawn;
    public Transform target;
    public AudioSource audio;
    public float range;
    public float damage;
    public GameObject bulletPrefab;
    public string targetTag ="";

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        audio.Play();
        

        RaycastHit hit;

        if (Physics.Raycast(bulletSpawn.transform.position, target.forward, out hit, range))
        {
            GameObject bullet = Instantiate(bulletPrefab, target.position, new Quaternion());
            Bullet blt = bullet.GetComponent<Bullet>();
            if (blt != null)
            {
                blt.targetTag = targetTag;
                blt.damage = damage;
            }
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
            if (bulletRB != null)
            {
                bulletRB.rotation = Quaternion.LookRotation(hit.point - transform.position);
                bulletRB.AddForce(bulletSpawn.forward * 1500f);
            }
        }
    }
}
