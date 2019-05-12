using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void NextScene()
    {
        SceneManager.LoadScene(1);
    }

    public void NextScene2()
    {
        SceneManager.LoadScene(2);
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
