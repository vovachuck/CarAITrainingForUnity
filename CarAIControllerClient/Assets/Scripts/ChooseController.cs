using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ChooseController : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }
    public void chooseFirstMap(){
        SceneManager.LoadScene(1);
    }
    public void chooseSecondMap(){
        SceneManager.LoadScene(3);
    }
    public void chooseFirstMapTrain(){
        SceneManager.LoadScene(2);
    }
    public void chooseSecondMapTrain(){
        SceneManager.LoadScene(6);
    }
}
