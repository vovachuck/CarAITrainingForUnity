using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
public class HelloClient : MonoBehaviour
{
    private HelloRequester helloRequester;
    public Camera cameraAI;

    
    private void Start()
    {
        helloRequester = new HelloRequester();
        InvokeRepeating("send", 0f, 0.1f);
    }
    void send(){

        helloRequester.sendRequest(CamCapture());
        helloRequester.sendRequestInput(CrossPlatformInputManager.GetAxis("Horizontal").ToString());
        
    }
    void OnApplicationQuit()
    {
        helloRequester.sendRequestQuit("stop");
    }
    void FixedUpdate()
    {
    
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