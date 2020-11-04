using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadMenuEventListener : MonoBehaviour
{
    public Button restartBtn;
    public Button exitBtn;


    void Start()
    {
        restartBtn.onClick.AddListener(onRestartClick);
        exitBtn.onClick.AddListener(onExitClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void onRestartClick()
    {
        StaticUIElements.instance.deadWindow.restart();
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
