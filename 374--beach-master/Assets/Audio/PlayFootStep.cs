using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFootStep : MonoBehaviour {

    private bool isWalking = false;
    private AudioSource FootStepSource;

	// Use this for initialization
	void Start () {
        FootStepSource = transform.Find("OVRCameraRig").gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void walk()
    {
        if (isWalking == false)
        {
            //lock on
            isWalking = true;

            StartCoroutine(BeginWalk());
        }
    }

    //callback when the audio is end, release the lock
    private void OnEnd()
    {
        //lock off
        isWalking = false;
    }

    private IEnumerator BeginWalk()
    {
        FootStepSource.Play();
        //delay function
        yield return new WaitForSeconds(FootStepSource.clip.length+ 0.3f);
        OnEnd();
    }
}
