using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.RotateAround(Vector3.zero, Vector3.up, -30.0f * Time.deltaTime);
    }
}
