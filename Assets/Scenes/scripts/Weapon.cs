using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage;
    public float fireRate;
    public float range;
    public ParticleSystem muzzleFlash;
    public Transform bulletSpawn;
    public AudioClip shotSFX;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        audioSource.PlayOneShot(shotSFX);
        muzzleFlash.time = 0;
        muzzleFlash.Play();

        RaycastHit hit;

        if (Physics.Raycast(bulletSpawn.transform.position, bulletSpawn.transform.forward, out hit, range))
        {
            Debug.DrawRay(bulletSpawn.transform.position, hit.point, Color.red);
            Debug.Log(hit.transform.gameObject.tag);
            if (hit.transform.gameObject.tag == "Mortal") {
                Health hl =hit.transform.gameObject.GetComponent<Health>();
                if(hl != null) hl.damage(damage);
            }
        }
    }
}
