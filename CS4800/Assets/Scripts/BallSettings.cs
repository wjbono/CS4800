using System;
using UnityEngine;
using UnityEngine.UI;

public class BallSettings : MonoBehaviour
{
    float minSize = 0.75f;
    float maxSize = 1.5f;
    float currentSize = 0.75f;
    float minY = 0.888f;
    float maxY = 1.222f;
    float currentY = 0.888f;

    bool goingUp = true;
    bool isSizing = false;
    ReflectionProbe rp;
    GameObject nearClipSlider, farClipSlider, realTimeToggle;
    // Start is called before the first frame update

    void Start()
    {
        rp = GetComponent<ReflectionProbe>();
        nearClipSlider = GameObject.FindGameObjectWithTag("ReflectionNCPSlider");
        farClipSlider = GameObject.FindGameObjectWithTag("ReflectionFCPSlider");
        realTimeToggle = GameObject.FindGameObjectWithTag("ReflectionRealtimeToggle");
    }

    private void Update()
    {
        if (nearClipSlider == null || farClipSlider == null || realTimeToggle == null)
        {
            nearClipSlider = GameObject.FindGameObjectWithTag("ReflectionNCPSlider");
            farClipSlider = GameObject.FindGameObjectWithTag("ReflectionFCPSlider");
            realTimeToggle = GameObject.FindGameObjectWithTag("ReflectionRealtimeToggle");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isSizing)
        {
            if (currentSize < maxSize && goingUp)
            {
                currentSize += 0.01f;
                currentY += 0.005f;
            }
            else
            {
                goingUp = false;
            }
            if (currentSize > minSize && !goingUp)
            {
                currentSize -= 0.01f;
                currentY -= 0.005f;
            }
            else
            {
                goingUp = true;
            }
            gameObject.transform.localScale = new Vector3(currentSize, currentSize, currentSize);
            gameObject.transform.position = new Vector3(0, currentY, 0);
        }
    }

    public void ToggleReflections()
    {
        rp.enabled = !rp.enabled;
        Debug.Log(realTimeToggle.name);
        realTimeToggle.GetComponent<Toggle>().interactable = rp.enabled;
        nearClipSlider.GetComponent<Slider>().interactable = rp.enabled;
        farClipSlider.GetComponent<Slider>().interactable = rp.enabled;
    }

    public void ToggleReflectionMode()
    {
        if (rp.mode == UnityEngine.Rendering.ReflectionProbeMode.Baked)
        {
            rp.mode = UnityEngine.Rendering.ReflectionProbeMode.Realtime;
            nearClipSlider.GetComponent<Slider>().interactable = true;
            farClipSlider.GetComponent<Slider>().interactable = true;
        }
        else
        {
            rp.mode = UnityEngine.Rendering.ReflectionProbeMode.Baked;
            nearClipSlider.GetComponent<Slider>().interactable = false;
            farClipSlider.GetComponent<Slider>().interactable = false;

        }
    }

    public void UpdateNCP()
    {
        float value = nearClipSlider.GetComponent<Slider>().value;
        rp.nearClipPlane = value;
    }

    public void UpdateFCP()
    {
        float value = farClipSlider.GetComponent<Slider>().value;
        rp.farClipPlane = value;
    }

}
