using UnityEngine;
using System.Collections;

public class RBFPS : MonoBehaviour
{
    public static RBFPS S;

    public float zeroVelocitySpeed = 8.0f;
    public float movementSpeed = 7.0f;
    public float mouseSensitivity = 2.0f;
    public float jumpSpeed = 4.0f;
    public float verticalRotation = 0;
    public float upDownRange = 90.0f;


    public Rigidbody rb;
    //SphereCollider sc;

    public bool surf = false;

    void Awake()
    {
        S = this;
        //Screen.lockCursor = true;
        rb = GetComponent<Rigidbody>();
        //sc = GetComponent<SphereCollider>();
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Rotation

        float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotLeftRight, 0);


        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);


        // Movement
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        Vector3 speed = new Vector3(sideSpeed, 0.0f, forwardSpeed);
        rb.AddRelativeForce(speed);

        speed = transform.rotation * speed; // ????

        if (!Input.GetKey(KeyCode.W) || !Input.GetKey(KeyCode.D))
        {
            rb.velocity = Vector3.MoveTowards(rb.velocity, new Vector3(0, rb.velocity.y, 0), (zeroVelocitySpeed * Time.deltaTime));
        }

        //if( cc.isGrounded && Input.GetButton("Jump") ) { verticalVelocity = jumpSpeed; }
        if (Input.GetButton("Jump"))
            rb.AddRelativeForce(0, jumpSpeed, 0, ForceMode.Impulse);

    }

}
