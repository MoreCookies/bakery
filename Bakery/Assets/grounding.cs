using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grounding : MonoBehaviour
{
    // Start is called before the first frame update
    public delegate void groundAct();
    public static event groundAct updateGround;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name != "Capsule")
        {
            Debug.Log("joe's mama");
            if(updateGround != null)
            {
                Debug.Log("change");
                updateGround();
            }
            
        }
        
    }
}
