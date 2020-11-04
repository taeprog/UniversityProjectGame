using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public Text helthValue;
    public Health playerHealth;
    private void Update()
    {
        setHealth(playerHealth.maxHealth, playerHealth.currentHealth);
    }
    // Start is called before the first frame update
    public void setHealth(float max, float currnt) {
        float percent = currnt / max * 100;
        helthValue.text = Mathf.Abs(percent).ToString() + "%";
    }
}
