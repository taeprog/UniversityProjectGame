using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadWindow : MonoBehaviour
{
    public GameObject deadMenu;
    private bool restarted = false;

    private void Awake()
    {
        Time.timeScale = 1;
    }
    void Start()
    {
        if (restarted) {
            Time.timeScale = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void show() {
        deadMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;
    }

    public void restart()
    {
        // Application.LoadLevel(Application.loadedLevel);
        Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene.name);
        SceneManager.instance.onLoaded();
        SceneManager.instance.cleanDrones();
    }
}
