using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionCtrl : MonoBehaviour
{
    private BLE bleMgr;
    private Rigidbody rigidbody;
    private RaycastHit hit;
    private bool onGround = false;
    public float jumpPower = 5.0f; 
    void Start()
    {
        bleMgr = BLE.instance;
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckGround();
        if (!bleMgr.bluetoothOn) return;
        if (float.Parse(bleMgr.message) == 1 && onGround)
        {
            rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);   
        }
    }

    private void CheckGround()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.3f))
        {
            if (hit.transform.CompareTag("GROUND"))
            {
                onGround = true;
            }
            else
            {
                onGround = false;
            }
        }
    }
}
