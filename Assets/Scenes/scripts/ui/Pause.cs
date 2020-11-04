using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPused = false;

    private AudioSource[] allAudioSources;
    void Start()
    {
        allAudioSources = FindObjectsOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPused)
            {
                resume();
            }
            else {
                pause();
            }
        }
    }

    public void pause() {
        pauseMenu.SetActive(true);
        isPused = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;

        foreach (AudioSource audio in allAudioSources) {
            if (audio.isActiveAndEnabled) {
                audio.Pause();
            }
            
        }
    }

    public void resume() {
        pauseMenu.SetActive(false);
        isPused = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        foreach (AudioSource audio in allAudioSources)
        {
            audio.Play();
        }
    }
}
