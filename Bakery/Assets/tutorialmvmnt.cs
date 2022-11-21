using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialmvmnt : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;

    public float spd = 2f;
    public float sprspd = 4f;
    public float gravity = 9.81f;
    public bool isGrounded = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal"); //mapped to wasd or arrow keys i think arrow keys though
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        if(Input.GetKey(KeyCode.LeftShift))
        {

        } else
        {
            controller.Move(move * spd * Time.deltaTime);
        }
        
    }

    void updateGrounded()
    {
        isGrounded = true;
    }
}
