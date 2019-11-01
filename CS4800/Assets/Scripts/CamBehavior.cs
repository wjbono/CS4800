using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamBehavior : MonoBehaviour
{
    Camera mc;
    CameraRotate cr;
    // Start is called before the first frame update
    void Start()
    {
        mc = Camera.main.GetComponent<Camera>();
        cr = Camera.main.GetComponent<CameraRotate>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateNCP()
    {
        float value = GameObject.FindGameObjectWithTag("CameraNCPSlider").GetComponent<Slider>().value;
        mc.nearClipPlane = value;
    }

    public void UpdateFCP()
    {
        float value = GameObject.FindGameObjectWithTag("CameraFCPSlider").GetComponent<Slider>().value;
        mc.farClipPlane = value;
    }

    public void UpdateUpVector()
    {
        float value = GameObject.FindGameObjectWithTag("CameraUpVectorSlider").GetComponent<Slider>().value;
        cr.rotationOffset = value * -1;
    }
}
