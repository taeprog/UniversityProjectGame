using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPicker : MonoBehaviour
{
    public Transform targetPoint;
    public float range = 1000;
    EnemyHealthBar bar;
    void Start()
    {
        bar = StaticUIElements.instance.enemyHealthBar;
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit[] hits = Physics.RaycastAll(targetPoint.position, targetPoint.forward, 100.0F);
        
        foreach (RaycastHit hit in hits) {
            if (hit.transform.gameObject.tag == "Mortal")
            {
                Health hl = hit.transform.gameObject.GetComponent<Health>();
                bar.setText(hit.transform.gameObject.name);
                bar.setHealthData(hl.maxHealth, hl.currentHealth);
                bar.show();
            }
            else
            {
                bar.hide();
            }
        }
    }
}
