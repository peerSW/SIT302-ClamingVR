using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CatleAnimation : MonoBehaviour
{

    [SerializeField] Transform rayOrigin;
    [SerializeField] Animator anim;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] clips;
    public string[] anims;
    public float timeRandom;
    public float resetTime;

    public bool isMove = true;
    float Speed;
    float FinalSpeed = 1;

    // 0 animation is walk
    // 1 animation is eat
    // 2 animation is idle
    public int randomAnimation = 0;

    bool isSoundPlay = false;

    private void Update()
    {
        RaycastCheckFence();

        if (isMove)
        {
            Speed = Mathf.MoveTowards(Speed, FinalSpeed, Time.deltaTime);
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }

        timeRandom -= Time.deltaTime;
        if (timeRandom <= 0)
        {
            randomAnimation = Random.Range(0, 3);
            Debug.Log("randomAnimation " + randomAnimation);
            timeRandom = resetTime;
            changeSound(randomAnimation);
        }

        RunAnimation();


    }

    public void SwapIdle()
    {
        Debug.Log("Swap animation");
    }

    void RaycastCheckFence()
    {
        Ray ray = new Ray(rayOrigin.position, transform.forward);
        //Debug.DrawRay(ray.origin, ray.direction * 1.5f, Color.yellow);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1.5f))
        {
            //Debug.Log("HIt" + hit.transform.name);
            if (hit.transform.tag == "Fence")
            {
                float ran = Random.Range(20, 180);
                transform.Rotate(new Vector3(0, ran , 0));
                isMove = false;
                anim.SetBool("isIdle", true);
            } 
            if (hit.transform.tag == "Cow")
            {
                float r = Random.Range(0, 10);
                if( r >= 0 && r < 5)
                {
                    isMove = false;
                    anim.SetBool("isIdle", true);
                }
                if(r >= 5 && r <= 10)
                {
                    float ran = Random.Range(20, 180);
                    transform.Rotate(new Vector3(0, ran, 0));
                    isMove = false;
                    anim.SetBool("isIdle", true);
                }
            }
        }
    }

    void RunAnimation()
    {
        if(randomAnimation == 0)
        {
            //Debug.Log("animation walk");
            isMove = true;
            CowAnimation(anims[0]);
        }
        else if (randomAnimation == 1)
        {
            //Debug.Log("animation eat");
            isMove = false;
            CowAnimation(anims[1]);
        }
        else if (randomAnimation == 2)
        {
            //Debug.Log("animation idle");
            isMove = false;
            CowAnimation(anims[2]);
        }
    }

    void CowAnimation(string animation)
    {
        foreach (var str in anims)
        {
            anim.SetBool(str, str.Equals(animation));
        }
    }

    void changeSound(int index)
    {
        audioSource.clip = clips[index];
        audioSource.Play();
        if (index == 1)
            audioSource.volume = 0.3f;
        else
            audioSource.volume = 1f;
    }
}
