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

    GameObject Camera;

    float rotationY = 0F;
    // Use this for initialization
    void Start () {
        Camera = transform.Find("OVRCameraRig").gameObject;
    }
	
	// Update is called once per frame
	void Update ()
    {
        move();
        rotate();
    }

    void move()
    {
        //move
        float horizontal = Input.GetAxis("Horizontal"); //A D 
        float vertical = Input.GetAxis("Vertical"); //W S 

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
