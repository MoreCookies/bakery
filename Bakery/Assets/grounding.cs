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
    // Update is called once per frame
    private void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 0.2f))
        {
            updateGround();
        } else
        {
            updateGround2();
        }
    }
}
