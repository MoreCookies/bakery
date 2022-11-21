using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float mouseSens = 100f;
    public Transform playerBody;
    float yRotate = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        yRotate -= mouseY;
        yRotate = Mathf.Clamp(yRotate, -90f, 90f);
        Debug.Log(mouseX);
        transform.localRotation = Quaternion.Euler(yRotate, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        //playerBody.Rotate(Vector3.up * mouseX);
        //transform.localRotation = Quaternion.EulerAngles(0f, mouseY, 0f);
        //playerBody.Rotate(new Vector3(-1, 0, 0) * Mathf.Clamp(mouseY, -90f, 90f));
    }
}
