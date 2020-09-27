using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseEventsListener : MonoBehaviour
{
    public Button resumeBtn;
    public Button exitBtn;

    public Pause pause;

    void Start()
    {
        resumeBtn.onClick.AddListener(onResumeClick);
        exitBtn.onClick.AddListener(onExitClick);
    }

    private void onResumeClick() {
        pause.resume();
    }
    private void onExitClick() {
        Debug.Log("Exit");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

}
