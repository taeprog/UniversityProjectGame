using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage;
    public float fireRate;
    public float range;
    public GameObject muzzleFlash;
    public Transform bulletSpawn;
    public AudioClip shotSFX;
    public AudioSource audioSource;

    public Camera camera;

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
        Instantiate(muzzleFlash, bulletSpawn.position, bulletSpawn.rotation);

        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            Debug.Log("Shot "+ hit.collider);
        }
    }
}
