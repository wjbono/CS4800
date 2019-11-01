using System;
using UnityEngine;
using UnityEngine.UI;

public class BallSettings : MonoBehaviour
{
    ReflectionProbe rp;
    // Start is called before the first frame update
    void Start()
    {
        rp = GetComponent<ReflectionProbe>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleReflections()
    {
        rp.enabled = !rp.enabled;
    }

    public void ToggleReflectionMode()
    {
        if (rp.mode == UnityEngine.Rendering.ReflectionProbeMode.Baked)
        {
            rp.mode = UnityEngine.Rendering.ReflectionProbeMode.Realtime;
        }
        else
        {
            rp.mode = UnityEngine.Rendering.ReflectionProbeMode.Baked;
        }
    }

    public void UpdateNCP()
    {
        float value = GameObject.FindGameObjectWithTag("ReflectionNCPSlider").GetComponent<Slider>().value;
        rp.nearClipPlane = value;
    }

    public void UpdateFCP()
    {
        float value = GameObject.FindGameObjectWithTag("ReflectionFCPSlider").GetComponent<Slider>().value;
        rp.farClipPlane = value;
    }
}
