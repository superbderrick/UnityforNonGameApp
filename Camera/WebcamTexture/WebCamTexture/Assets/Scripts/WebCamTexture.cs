using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCamTexture : MonoBehaviour
{
    public int Width = 1920;
    public int Height = 1080;
    public int FPS = 30;
    
    // Start is called before the first frame update
    void Start()
    {
        SetupForWebCamTexture();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetupForWebCamTexture()
    {
        var devices = WebCamTexture.devices;
        if (devices.Length > 0)
        {
            WebCamTexture webcamTexture = new WebCamTexture(Width, Height, FPS);
            gameObject.GetComponent<Renderer>().material.mainTexture = webcamTexture;
            webcamTexture.Play();
        }else
        {
            Debug.Log("Webカメラが検出できませんでした");
            return;
        }
    }
}
