using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : MonoBehaviour {

    public enum Destination
    {
        Beach,
        Lake,
        Countryside
    }

    public Destination destination = Destination.Lake;



    GameObject Person;
    Transform Spawner_Beach;
    Transform Spawner_Lake;
    private Vector3 StartPoint;
    private Vector3 EndPoint;
    //from start to end
    private Vector3 distance;
    //from current to end
    private Vector3 cur_distance;
    private bool isTravelling = false;
    private AudioSource WindSource;

   

    // Use this for initialization
    void Start () {
        Spawner_Beach = GameObject.Find("Spawner_beach").transform;
        Spawner_Lake = GameObject.Find("Spawner_lake").transform;
        Person = GameObject.Find("Person");
        WindSource = this.GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        if(isTravelling == true)
        {
            travelling(Time.deltaTime);
        }

    }
    // transport begin
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.transform == Person || isTravelling == false )
        {
            this.GetComponent<BoxCollider>().isTrigger = false;
            if (destination == Destination.Lake)
                BeginTravel(Spawner_Lake.position);
            if (destination == Destination.Beach)
                BeginTravel(Spawner_Beach.position);
        }
    }

    private void BeginTravel(Vector3 target)
    {
        //lock the movement from player
        Person.GetComponent<MovementControl>().m_lock = true;
       // Person.GetComponent<MovementControl>().r_lock = true;
        EndPoint = target;
        StartPoint = Person.transform.position;
        distance = StartPoint - EndPoint;
        distance.y = 0;
        cur_distance = distance;
        Person.GetComponent<Rigidbody>().useGravity = false;
        //Person.transform.Rotate();
        isTravelling = true;
        WindSource.Play();

    }
    private IEnumerator EndTravel()
    {
        WindSource.Pause();

       // Person.GetComponent<MovementControl>().r_lock = false;
        Person.GetComponent<Rigidbody>().useGravity = true;
        isTravelling = false;
        this.GetComponent<BoxCollider>().isTrigger = true ;

        yield return new WaitForSeconds(1.0f);
        //free the movement from player
        Person.GetComponent<MovementControl>().m_lock = false;

    }
    private void travelling(float deltaTime)
    {
        Vector3 moveVector = (EndPoint - Person.transform.position);

        cur_distance = Person.transform.position - StartPoint;
        cur_distance.y = 0;
        moveVector = moveVector.normalized;
       //moveVector *= deltaTime;
        if (cur_distance.magnitude< distance.magnitude/2)
        {
            moveVector.y = 0.5f;
        }
        if (cur_distance.magnitude < distance.magnitude)
        {
            Person.transform.position = Person.transform.position + moveVector*deltaTime*90;
            //Quaternion newRotation = Quaternion.LookRotation(moveVector+new Vector3(0,1.0f,0));
           // Person.transform.rotation = Quaternion.RotateTowards(Person.transform.rotation, newRotation, 50 * Time.deltaTime);
        }
        else
        {
            isTravelling = false;
            StartCoroutine(EndTravel()); 
        }

    }

}
