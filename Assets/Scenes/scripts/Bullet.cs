using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public string targetTag = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (targetTag.Length != 0 && collision.gameObject.tag.Equals(targetTag))
        {
            return;
        }

        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null) {
            
            health.damage(damage);
            Destroy(this.gameObject);
        }
        Destroy(this.gameObject);
        

    }
}
