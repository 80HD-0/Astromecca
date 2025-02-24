using System.Runtime.InteropServices;
using UnityEngine;

public class Cameravert : MonoBehaviour
{
    public Transform camera;
    public float sensetivity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        float turnAmount = mouseY * sensetivity * Time.deltaTime;
        print(turnAmount);
        print(mouseY);
        Quaternion targetRotation = Quaternion.Euler(camera.eulerAngles.x + turnAmount, camera.eulerAngles.y, camera.eulerAngles.z);
    }
}
