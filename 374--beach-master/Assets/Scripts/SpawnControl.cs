using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour {

    Transform Person;
    Transform SpawnPoint;

    public enum spawnPosition
    {
        Spawn_beach,
        Spawn_lake
    }
    public spawnPosition position = spawnPosition.Spawn_beach;
   // public spawnPosition lake_position = spawnPosition.Spawn_lake;
    void Start() {
        if (position == spawnPosition.Spawn_beach) {
            SpawnPoint = GameObject.Find("Spawner_beach").transform;
        }
        else if (position == spawnPosition.Spawn_lake) {
            SpawnPoint = GameObject.Find("Spawner_lake").transform;
        }
       
        Person = GameObject.Find("OVRCameraRig").transform;

        Person.transform.position = SpawnPoint.transform.position;
    }

}
