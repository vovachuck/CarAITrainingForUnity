using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    
    public class CarUserControlTrain : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use



        private void Awake()
        {

            m_Car = GetComponent<CarController>();


        }


        private void FixedUpdate()
        {
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            //float v = CrossPlatformInputManager.GetAxis("Vertical");
            float v=0.04f;
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, v, v, handbrake);
            m_Car.Move(h, v, v, 0f);
        }
    }
}
