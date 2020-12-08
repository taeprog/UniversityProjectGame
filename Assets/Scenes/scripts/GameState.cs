using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameState
{
    public string SceneName;
    public int checkpointId;
    public Actor Player;
    public Drone[] Drones;


    [System.Serializable]
    public class Actor {
        public float Health;
        public float[] Position;
        public float[] Rotation;

        
        public Actor(float health, GameObject actor)
        {
            Health = health;
            Position = new float[3]{ actor.transform.position.x,actor.transform.position.y,actor.transform.position.z};
            Rotation = new float[4] { actor.transform.rotation.w, actor.transform.rotation.x, actor.transform.rotation.y, actor.transform.rotation.z };
        }
    }

    [System.Serializable]
    public class Drone:Actor {
        public int id;

        public Drone(float health, GameObject drone):base(health,drone)
        {
            id = drone.GetComponent<Copter>().getId();
        }
    }

   
}
