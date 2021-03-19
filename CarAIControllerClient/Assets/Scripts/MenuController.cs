using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuController : MonoBehaviour
{
    public Text fps;
    void Start()
    {
        Application.targetFrameRate = 30;
    }
    void Update()
    {
        int res= (int)(1.0f / Time.deltaTime);
        fps.text=res.ToString();
    }
    public void play(){
        SceneManager.LoadScene(4);
    }
    public void train(){
        SceneManager.LoadScene(5);
    }
    public void exit(){
        SceneManager.LoadScene("Main");
    }

}
