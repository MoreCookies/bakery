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
    public float baseFOV = 60f;
    public float targetFOV = 100f;
    public float accel = 1f;
    private void OnEnable()
    {
        grounding.updateGround += updateGrounded;
    }

    private void OnDisable()
    {
        grounding.updateGround -= updateGrounded;
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
        if(!isGrounded)
        {
            //Physics.gravity = new Vector3(0, gravity, 0);
            gravity -= accel;
            controller.Move(new Vector3(0, gravity*Time.deltaTime, 0));
        }
        //Debug.Log(isGrounded);
        
    }

    void updateGrounded()
    {
        Debug.Log("changings");
        isGrounded = true;
    }
}
