using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grounding : MonoBehaviour
{
    // Start is called before the first frame update
    public delegate void groundAct();
    public static event groundAct updateGround;

    public delegate void groundAct2();
    public static event groundAct updateGround2;

    bool isGrounded = false;
    bool updatedGrounded = false;
    // Update is called once per frame
    private void Update()
    {
        /*
        if(!updatedGrounded)
        {
            updateGround2();
        }
        updatedGrounded = false;
        */
        if (Physics.Raycast(transform.position, Vector3.down, 0.2f))
        {
            updateGround();
        } else
        {
            updateGround2();
        }
    }
    /*
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name != "Capsule" && collision.gameObject.name != "Player")
        {
            
            if (updateGround2 != null)
            {
                Debug.Log("changing to false");
                isGrounded = false;
                //updatedGrounded = false;
                updateGround2();
            }

        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log(collision.gameObject.name);   
        if(collision.gameObject.name != "Capsule" && collision.gameObject.name != "Player")
        {
            if (updateGround != null)
            {
                isGrounded = true;
                updateGround();
                updatedGrounded = true;
            }
            
        }
        
    }
    */
}
