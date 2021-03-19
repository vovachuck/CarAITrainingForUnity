using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using NetMQ;
using NetMQ.Sockets;
using System.Globalization;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    
    public class CarAIControl : MonoBehaviour
    {
        private HelloRequester helloRequester;
        public Camera cameraAI;
        private CarController m_Car; // the car controller we want to use

        private float h=0f;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
            helloRequester = new HelloRequester();
            InvokeRepeating("send", 0f, 0.2f);
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            //float h = CrossPlatformInputManager.GetAxis("Horizontal");
            //float v = CrossPlatformInputManager.GetAxis("Vertical");
            float v=1f;
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, v, v, handbrake);
            m_Car.Move(h, v, v, 0f);
        }
        void send(){
            try
            {
                h = float.Parse(helloRequester.sendRequestPredict(CamCapture()), CultureInfo.InvariantCulture.NumberFormat);
                NetMQConfig.Cleanup();
            }
            catch
            {
                h=0f;
                NetMQConfig.Cleanup();
            } 
        }
        byte[] CamCapture()
        {
            RenderTexture currentRT = RenderTexture.active;
            RenderTexture.active = cameraAI.targetTexture;
    
            cameraAI.Render();
    
            Texture2D Image = new Texture2D(cameraAI.targetTexture.width, cameraAI.targetTexture.height);
            Image.ReadPixels(new Rect(0, 0, cameraAI.targetTexture.width, cameraAI.targetTexture.height), 0, 0);
            Image.Apply();
            RenderTexture.active = currentRT;
    
            byte[] Bytes = Image.EncodeToPNG();
            Destroy(Image);
            return Bytes;

        }
    }
}
