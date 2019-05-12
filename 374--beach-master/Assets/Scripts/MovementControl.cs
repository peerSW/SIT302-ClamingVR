using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour {

    private Rigidbody body;
    public float move_speed = 5f;
    //rotate sensitive
    public float sensitivityX = 10F;
    public float sensitivityY = 10F;


    //Max and min in Y 
    public float minimumY = -60F;
    public float maximumY = 60F;

    public bool m_lock = false;
    public bool r_lock = false;

    GameObject Camera;
    PlayFootStep AudiotScript;

    float rotationY = 0F;
    // Use this for initialization
    void Start () {
        Camera = transform.Find("OVRCameraRig").gameObject;
        AudiotScript = gameObject.GetComponent<PlayFootStep>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (m_lock == false)
        {
            move();
        }
        if(r_lock ==false)
        {
            rotate();
        }
    }

    void move()
    {
        //move
        float horizontal = Input.GetAxis("Horizontal"); //A D 
        float vertical = Input.GetAxis("Vertical"); //W S 

        if (horizontal != 0 || vertical != 0)
        {

            AudiotScript.walk();
        }

        transform.Translate(Vector3.forward * vertical * move_speed * Time.deltaTime);//W S 
        transform.Translate(Vector3.right * horizontal * move_speed * Time.deltaTime);//A D 
    }

    void rotate()
    {
        //deal with X
        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;


        //deal with Y 
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        //angle limit 
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);


        //set the angle
        transform.localEulerAngles = new Vector3(0, rotationX, 0);
        Camera.transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
    }

    
}
