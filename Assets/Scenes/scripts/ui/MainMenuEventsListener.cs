using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuEventsListener : MonoBehaviour
{
    public Button exitBtn;
    void Start()
    {
        exitBtn.onClick.AddListener(onExitClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void onExitClick()
    {
        Debug.Log("Exit");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
