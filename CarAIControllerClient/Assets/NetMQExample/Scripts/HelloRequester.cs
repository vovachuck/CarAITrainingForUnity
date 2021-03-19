using AsyncIO;
using NetMQ;
using NetMQ.Sockets;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Globalization;
public class HelloRequester : MonoBehaviour
{
    
    public void sendRequest(byte[] imageAI)
    {
        ForceDotNet.Force();
        using (RequestSocket client = new RequestSocket())
        {
            client.Connect("tcp://localhost:5555");
            Debug.Log("Sending Picture");
            client.SendFrame(imageAI);
            string message = null;
            bool gotMessage = false;
            while (true)
            {
                gotMessage = client.TryReceiveFrameString(out message);
                if (gotMessage) break;
                if(Input.GetKeyDown(KeyCode.Escape))break;
            }

                if (gotMessage) Debug.Log("Received " + message);
            
        }

        NetMQConfig.Cleanup();
    }

    public string sendRequestPredict(byte[] imageAI)
    {
        ForceDotNet.Force();
        using (RequestSocket client = new RequestSocket())
        {
            client.Connect("tcp://localhost:5555");
            Debug.Log("Sending Picture");
            client.SendFrame(imageAI);
            string message = null;
            bool gotMessage = false;
            while (true)
            {
                gotMessage = client.TryReceiveFrameString(out message);
                if (gotMessage) break;
            }

            if (gotMessage) {
                Debug.Log("Received " + message);
                //return float.Parse(message, CultureInfo.InvariantCulture.NumberFormat);
                return message;
            }
            //return 0f;
            return null;
            
        }

        
    }
    public void sendRequestQuit(string  text)
    {
        ForceDotNet.Force();
        using (RequestSocket client = new RequestSocket())
        {
            client.Connect("tcp://localhost:5555");
            Debug.Log("Sending Quit");
            client.SendFrame(text);
            string message = null;
            bool gotMessage = false;
            while (true)
            {
                gotMessage = client.TryReceiveFrameString(out message);
                if (gotMessage) break;
                if(Input.GetKeyDown(KeyCode.Escape))break;
            }

                if (gotMessage) Debug.Log("Received " + message);
            
        }

        NetMQConfig.Cleanup();
    }
    public void sendRequestInput(string  inputX)
    {
        ForceDotNet.Force();
        using (RequestSocket client = new RequestSocket())
        {
            client.Connect("tcp://localhost:5555");
            Debug.Log("Sending String");
            client.SendFrame(inputX);
            string message = null;
            bool gotMessage = false;
            while (true)
            {
                gotMessage = client.TryReceiveFrameString(out message);
                if (gotMessage) break;
                if(Input.GetKeyDown(KeyCode.Escape))break;
            }

                if (gotMessage) Debug.Log("Received " + message);
            
        }

        NetMQConfig.Cleanup();
    }
}