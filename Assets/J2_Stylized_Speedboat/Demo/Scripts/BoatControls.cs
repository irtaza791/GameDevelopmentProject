using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatControls : MonoBehaviour
{
    //Feel free to set the speeds to anything you like.
    public GameObject propeller;
    public GameObject wheel;
    public GameObject tiller;

    public float propRotSpeed = 1000.0f;
    public float wheelRotSpeed = 180.0f;
    public float tillerMoveSpeed = 90f;
    public float speed = 10.0f; // speed of the boat
    public float rotationSpeed = 100.0f; // rotation speed of the boat
    private Quaternion wheelBaseRotation;
    private Quaternion tillerBaseRotation;
    public float boatSpeed = 10f; // Speed of the boat
    public float turnSpeed = 50f;
    private Rigidbody rb;
    // Grab origins for return-to-position behavior
    void Start()
    {
        wheelBaseRotation = wheel.transform.localRotation;
        tillerBaseRotation = tiller.transform.localRotation;
        rb = GetComponent<Rigidbody>();
        rb.drag = 1;
    }

    //A basic rotation around a local axis.
    private void RotatePropellor()
    {
        propeller.transform.Rotate(1 * propRotSpeed * Time.deltaTime, 0, 0, Space.Self);
    }
    private void MoveBoat()
    {
        // Move the boat forward
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            rb.AddForce(-transform.right * boatSpeed);
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            rb.AddForce(transform.right * boatSpeed);
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        }



    }

    private void RotateWheel()
    {
        //Left Turn
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            wheel.transform.Rotate(-1 * wheelRotSpeed * Time.deltaTime, 0, 0, Space.Self);
        }
        //Right Turn
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            wheel.transform.Rotate(1 * wheelRotSpeed * Time.deltaTime, 0, 0, Space.Self);
        }
        //Reset wheel back to original rotation
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            wheel.transform.localRotation = Quaternion.Slerp(wheel.transform.localRotation, wheelBaseRotation, Time.deltaTime * 0.025f * wheelRotSpeed);
        }
    }

    private void MoveTiller()
    {
        //the tiller must move opposite the direction of the turn. Limits found by trial and error.
        if (tiller.transform.rotation.z <= -0.27f || tiller.transform.rotation.z >= 0.27f)
        {

        }
        else
        {
            //Left Turn
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                tiller.transform.Rotate(0, 0, 1 * tillerMoveSpeed * Time.deltaTime, Space.Self);
            }
            //Right Turn
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                tiller.transform.Rotate(0, 0, -1 * tillerMoveSpeed * Time.deltaTime, Space.Self);
            }
        }
        //Reset tiller back to original rotation
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            tiller.transform.localRotation = Quaternion.Slerp(tiller.transform.localRotation, tillerBaseRotation, Time.deltaTime * .025f * tillerMoveSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {

        MoveBoat();
        RotatePropellor();
        RotateWheel();
        MoveTiller();
    }
}