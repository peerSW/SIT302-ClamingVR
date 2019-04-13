using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour {

    Transform Person;
    Transform Spawner_Beach;
    Transform Spawner_Lake;

    //public enum spawnPosition
    //{
    //    Spawn_beach,
    //    Spawn_lake
    //}
    //public spawnPosition position = spawnPosition.Spawn_beach;
   // public spawnPosition lake_position = spawnPosition.Spawn_lake;
    void Start() {
        Spawner_Beach = GameObject.Find("Spawner_beach").transform;
        Spawner_Lake = GameObject.Find("Spawner_lake").transform;

        Person = gameObject.GetComponent<Transform>();

        //Person.transform.position = SpawnPoint.transform.position;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            SpawnAtBeach();
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            SpawnAtLake();
        }
    }

    void SpawnAtBeach()
    {
        Person.transform.position = Spawner_Beach.transform.position;
    }

    void SpawnAtLake()
    {
        Person.transform.position = Spawner_Lake.transform.position;
    }

}
