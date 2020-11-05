using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuEventsListener : MonoBehaviour
{
    public Button newGameBtn;
    public Button resumeBtn;
    public Button exitBtn;

    void Start()
    {
        newGameBtn.onClick.AddListener(onNewGameClick);
        resumeBtn.onClick.AddListener(onResumeClick);
        exitBtn.onClick.AddListener(onExitClick);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void onNewGameClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }
    
    private void onResumeClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    private void onExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
  