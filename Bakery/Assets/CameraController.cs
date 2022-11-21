using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody beanrb;
    public GameObject foo;
    public int mvspd = 1;
    public int sprspd = 2;
    public float cmspd = 10f;
    private bool canJump = false;
    private bool doLog = false;
    void Start()
    {
        beanrb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        doLog = false;
        Vector3 newspd = new Vector3(0, 0, 0);
        if(Input.GetKey(KeyCode.W)) {
            newspd = new Vector3(newspd.x , newspd.y, newspd.z + mvspd);
            doLog = true;
        }
        if (Input.GetKey(KeyCode.A)) {
            newspd = new Vector3(newspd.x - mvspd, newspd.y, newspd.z);
            doLog = true;
        }
        if (Input.GetKey(KeyCode.S)) {
            newspd = new Vector3(newspd.x, newspd.y, newspd.z - mvspd);
            doLog = true;
        }
        if (Input.GetKey(KeyCode.D)) {
            newspd = new Vector3(newspd.x + mvspd, newspd.y, newspd.z);
            doLog = true;
        }
        if (Input.GetKey(KeyCode.Space) && canJump) {
            newspd = new Vector3(newspd.x, newspd.y+mvspd, newspd.z);
            doLog = true;
            canJump = false;
        }
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            foo.transform.rotation = Quaternion.Euler(cmspd * (new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * Time.deltaTime));
            //Debug.Log("Changing camera pos");
        }
        if (doLog)
        {
            //Debug.Log(newspd);
        }
        beanrb.transform.Translate(newspd);
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
