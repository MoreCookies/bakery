using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialmvmnt : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;

    public float spd = 2f;
    public float sprspd = 4f;
    public float OrgGravity = -5;
    
    public bool isGrounded = false;
    public float baseFOV = 60f;
    public float targetFOV = 100f;
    public float accel = 1f;
    public float jump = 3f;
    float fov;
    bool changingFov = false;

    public Camera camera;

    float gravity;
    private void OnEnable()
    {
        grounding.updateGround += updateGrounded;
        grounding.updateGround2 += updateGrounded2;
    }

    private void OnDisable()
    {
        grounding.updateGround -= updateGrounded;
        grounding.updateGround2 -= updateGrounded2;
    }

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal"); //mapped to wasd or arrow keys i think arrow keys though
        float z = Input.GetAxis("Vertical");
        camera.fieldOfView = fov;

        Vector3 move = transform.right * x + transform.forward * z;
        if(Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * sprspd * Time.deltaTime);
            fov = targetFOV;
        } else
        {
            fov = baseFOV;
            controller.Move(move * spd * Time.deltaTime);
        }
        /*
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("jumping");
            controller.Move(Vector3.up * jump * Time.deltaTime);
            //gravity = jump;
            isGrounded = false;
        }
        */
        Debug.Log(isGrounded);
        if(!isGrounded)
        {
            //Physics.gravity = new Vector3(0, gravity, 0);
            gravity -= accel;
            controller.Move(new Vector3(0, gravity*Time.deltaTime, 0));
        } else
        {
            gravity = OrgGravity;
        }
        //Debug.Log(gravity);
        
    }

    void updateGrounded()
    {
        //Debug.Log("is now true");
        isGrounded = true;
    }

    void updateGrounded2()
    {
        //Debug.Log("is now false");
        isGrounded = false;
    }
}
