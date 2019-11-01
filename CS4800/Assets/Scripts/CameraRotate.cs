using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float rotationOffset;
	bool goingUp = false;
    float x, y;
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        rotationOffset = 0;
    }

	// Update is called once per frame
	void FixedUpdate()
	{
		Camera.main.transform.RotateAround(Vector3.zero, Vector3.up, 15.0f * Time.deltaTime);
        Camera.main.transform.LookAt(new Vector3(0, 0.512f, 0));
        y = (Mathf.Cos(Time.time - startTime) + 2.5f / 1.25f);
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, y, Camera.main.transform.position.z);
        Quaternion newRotation = new Quaternion();
        newRotation.eulerAngles = new Vector3(Camera.main.transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, rotationOffset);
        Camera.main.transform.rotation = newRotation;
	}
}
