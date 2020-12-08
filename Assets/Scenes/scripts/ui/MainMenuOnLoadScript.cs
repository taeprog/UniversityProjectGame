using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuOnLoadScript : MonoBehaviour
{
    public Button button;


    private void Awake()
    {
        SaveLoadSystem.load();
        if (SaveLoadSystem.gameState == null) {
            button.enabled = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
