using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour {
    public float speed = 6;
    public float jetSpeed = 14;
    public float gravity = -9.8f;
    private CharacterController _charController;

	// Use this for initialization
	void Start ()
    {
        _charController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
        float deltaX = 0;
        float deltaZ = 0;
        if (!GameReference.freezePlayerMovement)
        {
            //Player movement input
            //These aren't set if player is frozen
            deltaX = Input.GetAxis("Horizontal") * speed;
            deltaZ = Input.GetAxis("Vertical") * speed;
        }
        float deltaY = 0;
        if (Input.GetKey("space") ) {
            deltaY = jetSpeed;
        }

        //transform.Translate(deltaX * Time.deltaTime, 0, deltaY * Time.deltaTime);
        Vector3 movement = new Vector3(deltaX, gravity+deltaY, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
	}
}
