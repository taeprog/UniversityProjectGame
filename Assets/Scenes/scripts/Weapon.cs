using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage;
    public float fireRate;
    public float range;
    public GameObject bulletPrefab;
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

        //RaycastHit hit;

        /*if (Physics.Raycast(bulletSpawn.transform.position, bulletSpawn.transform.forward, out hit, range))
        {
            if (hit.transform.gameObject.tag == "Mortal") {*/
        RaycastHit[] hits = Physics.RaycastAll(bulletSpawn.transform.position, bulletSpawn.transform.forward, 100.0F);

        foreach (RaycastHit hit in hits)
        {
            if (hit.transform.gameObject.tag == "Mortal")
            {
                Health hl = hit.transform.gameObject.GetComponent<Health>();
                if (hl != null) hl.damage(damage);
            }
        }

        GameObject bullet = Instantiate(bulletPrefab, muzzleFlash.transform.position, new Quaternion());
        Bullet blt = bullet.GetComponent<Bullet>();
        if (blt != null) {
            blt.damage = 0;
        }
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
        if (bulletRB != null) {
            bulletRB.rotation = Quaternion.LookRotation(hits[0].point - transform.position);
            bulletRB.AddForce(bulletSpawn.forward * 1500f);
        }
    }
}
