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
    public bool isVR = true;

    GameObject Camera;
    PlayFootStep AudiotScript;
 //   OVRHeadsetEmulator VREmulator;
   // bool isVRactive = false;

    float rotationY = 0F;
    // Use this for initialization
    void Start () {
        Camera = transform.Find("OVRCameraRig").gameObject;
        AudiotScript = gameObject.GetComponent<PlayFootStep>();
        //for platform consistent
      //  VREmulator = Camera.GetComponent<OVRHeadsetEmulator>();
      //  if (VREmulator.IsEmulationActivated())
      ///  {
         //   isVRactive = true;
       // }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (m_lock == false)
        {
            move();
        }
        if(r_lock == false && isVR == false)
        {
            rotate();
        }
    }

    void move()
    {
        //move
        float horizontal = Input.GetAxis("Horizontal"); //A D 
        float VRhorizontal = Input.GetAxis("Oculus_GearVR_DpadX");
        float vertical = Input.GetAxis("Vertical"); //W S 
        float VRvertical = Input.GetAxis("Oculus_GearVR_DpadY");

        if (horizontal+ VRhorizontal != 0 || vertical+ VRvertical != 0)
        {

            AudiotScript.walk();
        }

        Vector3 forward =  Camera.transform.forward;
        forward.y = 0.0f;
        forward.Normalize();
        Vector3 right = Camera.transform.right;
        right.y = 0.0f;
        right.Normalize();

        transform.Translate( forward * (vertical+VRvertical) * move_speed * Time.deltaTime);//W S 
        transform.Translate( right * (horizontal+VRhorizontal) * move_speed * Time.deltaTime);//A D 
    }

    void rotate()
    {
        //deal with X
        float rotationX = transform.localEulerAngles.y+ Camera.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;


        //deal with Y 
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        //angle limit 
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);


        //set the angle
        //transform.localEulerAngles = new Vector3(0, rotationX, 0);
        Camera.transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }

    
}
