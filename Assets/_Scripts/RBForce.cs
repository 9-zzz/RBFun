using UnityEngine;
using System.Collections;

public class RBForce : MonoBehaviour
{

    Rigidbody rb;
    public float force;
    GameObject cam;
    GameObject pointer;

    public Vector3 lookForcePoint;

    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        cam = transform.GetChild(0).gameObject;
        pointer = transform.GetChild(1).gameObject;
    }

    void Start()
    {

    }

    void Update()
    {
        lookForcePoint = (transform.position - cam.transform.position);

        if (Input.GetKey(KeyCode.W))
            rb.AddForce((force * lookForcePoint), ForceMode.Acceleration);

        if (Input.GetKey(KeyCode.S))
            rb.AddForce((-force * lookForcePoint), ForceMode.Acceleration);


        //transform.LookAt(lookForcePoint);
    }

}
