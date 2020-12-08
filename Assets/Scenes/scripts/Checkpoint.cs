using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private int id;
    private bool passed = false;
    // Start is called before the first frame update
  
    void Start()
    {
        id = (int)(transform.position.x + transform.position.y + transform.position.z);
        if (SaveLoadSystem.gameState != null)
        {
            passed = SaveLoadSystem.gameState.checkpointId == id;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !passed)
        {
            passed = true;
            Save();
        }
    }

    void Save() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] drones = GameObject.FindGameObjectsWithTag("Mortal");
        GameState state = new GameState();
        state.SceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        float playerHealth = player.GetComponent<Health>().currentHealth;
        state.Player = new GameState.Actor(playerHealth, player);
        List<GameState.Drone> dronesData = new List<GameState.Drone>();
        for(int i=0; i<drones.Length; i++) {
            if (drones[i] != null) {
                Health droneHealthObj = drones[i].GetComponent<Health>();
                if (droneHealthObj != null) {
                    float droneHealth = droneHealthObj.currentHealth;
                    if (droneHealth > 0) {
                        dronesData.Add(new GameState.Drone(droneHealth, drones[i]));
                    }
                }
            }
        }
        state.Drones = dronesData.ToArray();
        state.checkpointId = id;
        SaveLoadSystem.Save(state);
        Debug.Log(SaveLoadSystem.gameState.Drones.Length);
    }
}
