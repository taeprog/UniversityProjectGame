using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public TextMeshProUGUI enemyName;
    public Slider bar;
    // Start is called before the first frame update

    public void setText(string text) {
       enemyName.text = text;
    }

    public void setHealthData(float max, float current) {
        bar.maxValue = max;
        bar.value = current;
    }
    public void hide() {
        this.gameObject.SetActive(false);
    }
    public void show()
    {
        this.gameObject.SetActive(true);
    }
}
