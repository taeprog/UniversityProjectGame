using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    #region Singleton
    public static SceneManager instance;
    

    private void Awake()
    {
        instance = this;
        onLoaded();
    }

    #endregion



    public GameObject player;
    public void onLoaded() {
        if (SaveLoadSystem.gameState != null) {
            GameState state = SaveLoadSystem.gameState;
            //player.transform.position.x = state.Player.Position[0];

            Vector3 playerPos = new Vector3(state.Player.Position[0], state.Player.Position[1], state.Player.Position[2]);
            Quaternion playerRot = new Quaternion(state.Player.Rotation[1], state.Player.Rotation[2], state.Player.Rotation[3], state.Player.Rotation[0]);
            player.transform.SetPositionAndRotation(playerPos, playerRot);
            Health playerHealth = player.GetComponent<Health>();
            if (playerHealth != null) {
                playerHealth.currentHealth = state.Player.Health;
            }
        }
    }

    public void cleanDrones()
    {
        if (SaveLoadSystem.gameState != null)
        {
            GameState state = SaveLoadSystem.gameState;
            GameObject[] drones = GameObject.FindGameObjectsWithTag("Mortal");
            for (int i = 0; i < drones.Length; i++)
            {
                GameState.Drone savedDrone = Array.Find(state.Drones, (a) => a.id == drones[i].GetComponent<Copter>().getId());
                if (savedDrone == null)
                {
                    Debug.Log("" + drones[i].GetComponent<Copter>().getId());
                    Destroy(drones[i]);

                }
                else
                {
                    Vector3 dronePos = new Vector3(savedDrone.Position[0], savedDrone.Position[1], savedDrone.Position[2]);
                    Quaternion droneRot = new Quaternion(savedDrone.Rotation[1], savedDrone.Rotation[2], savedDrone.Rotation[3], savedDrone.Rotation[0]);
                    drones[i].transform.SetPositionAndRotation(dronePos, droneRot);
                    Health droneHealth = drones[i].GetComponent<Health>();
                    if (droneHealth != null)
                    {
                        droneHealth.currentHealth = savedDrone.Health;
                    }
                }
            }
        }
    }
    
}
