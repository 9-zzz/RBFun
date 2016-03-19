using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class FPS : MonoBehaviour {
	
	public float movementSpeed = 7.0f;
	public float mouseSensitivity = 2.0f;
	public float jumpSpeed = 4.0f;
	
	float verticalRotation = 0;
	public float upDownRange = 90.0f;
	
	float verticalVelocity = 0;
	
	CharacterController cc;
    Rigidbody rb;
    SphereCollider sc;

    public bool surf = false;
	
	void Awake() {
		//Screen.lockCursor = true;
		cc= GetComponent<CharacterController>();
		rb= GetComponent<Rigidbody>();
		sc= GetComponent<SphereCollider>();

        rb.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		// Rotation
		
		float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
		transform.Rotate(0, rotLeftRight, 0);

		
		verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
		verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
		Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
		

		// Movement
		
		float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
		float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;
		
		verticalVelocity += Physics.gravity.y * Time.deltaTime;
		
		if( cc.isGrounded && Input.GetButton("Jump") ) {
			verticalVelocity = jumpSpeed;
		}
		
		Vector3 speed = new Vector3( sideSpeed, verticalVelocity, forwardSpeed );
		
		speed = transform.rotation * speed;


        if (!surf)
            cc.Move(speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift)) surf = true;

        if (Input.GetKeyUp(KeyCode.LeftShift)) surf = false;

        if (surf)
        {
            cc.enabled = false;
            rb.isKinematic = false;
            sc.enabled = true;
        }

        if (!surf)
        {
            cc.enabled = true;
            rb.isKinematic = true;
            sc.enabled = false;
        }

    }
}
