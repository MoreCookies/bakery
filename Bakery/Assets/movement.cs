using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody beanrb;
    public int mvspd = 1;
    public int sprspd = 2;
    private bool canJump = false;
    void Start()
    {
        beanrb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newspd = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            newspd = new Vector3(newspd.x, newspd.y, newspd.z + mvspd);
        }
        if (Input.GetKey(KeyCode.A))
        {
            newspd = new Vector3(newspd.x - mvspd, newspd.y, newspd.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            newspd = new Vector3(newspd.x, newspd.y, newspd.z - mvspd);
        }
        if (Input.GetKey(KeyCode.D))
        {
            newspd = new Vector3(newspd.x + mvspd, newspd.y, newspd.z);
        }
        if (Input.GetKey(KeyCode.Space) && canJump)
        {
            newspd = new Vector3(newspd.x, newspd.y + mvspd, newspd.z);
            canJump = false;
        }
        beanrb.velocity = newspd;
    }

    private void onCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Ground")
        {
            Debug.Log("touched ground");
            canJump = true;
        }
    }
}
