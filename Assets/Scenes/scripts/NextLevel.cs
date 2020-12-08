using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public int nextLevel;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            SaveLoadSystem.gameState = null;
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextLevel);
        }
    }
}
