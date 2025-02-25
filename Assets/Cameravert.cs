using System;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using UnityEngine;

public class cameravert : MonoBehaviour
{
    public Transform eyes;
    public float sensetivity;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 eyesrot = eyes.eulerAngles;
        float mouseY = Input.GetAxis("Mouse Y");
        float turnAmount = mouseY * sensetivity * Time.deltaTime;
        eyesrot.x -= turnAmount;
        if (eyesrot.x > 180)
        {
            eyesrot.x -= 360;
        }
        eyesrot.x = Mathf.Clamp(eyesrot.x, -90f, 90f);
        eyes.eulerAngles = eyesrot;
    }
}
