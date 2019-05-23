using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTriggerLoadLevel : MonoBehaviour {

    public string countrysideSceneName = "Countryside";
    public SceneFader sceneFader;


    GameObject Person;
    private Vector3 StartPoint;

    //from start to end
    private Vector3 distance;
    //from current to end
    private Vector3 cur_distance;
    private bool isTravelling = false;


    void Start()
    {
        Person = GameObject.Find("Person");
    }

    // Update is called once per frame
    void OnTriggerStay(Collider plyr)
    {
        if (plyr.gameObject.tag == "Person")
        {

            Countryside();

 
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.transform == Person || isTravelling == false)
        {
            this.GetComponent<BoxCollider>().isTrigger = false;
            Countryside();
            Debug.Log("Move");
        }
    }

    private void BeginTravel(Vector3 target)
    {
        //lock the movement from player
        Person.GetComponent<MovementControl>().m_lock = true;
        Person.GetComponent<MovementControl>().r_lock = true;
        
        StartPoint = Person.transform.position;
      
        distance.y = 0;
        cur_distance = distance;
        Person.GetComponent<Rigidbody>().useGravity = false;
        //Person.transform.Rotate();
        isTravelling = true;
        

    }

    public void Countryside()
    {
        // Move to Beach Scene
        sceneFader.FadeTo(countrysideSceneName);
    }
}
