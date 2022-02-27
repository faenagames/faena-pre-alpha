using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour {
    //Define an enum data structure to associate names with settings.
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    //Declare a public variable to set in Unity's editor.
    public RotationAxes axes = RotationAxes.MouseXAndY;
	// Use this for initialization
	void Start () {
	
	}

    //speed of rotation
    public static float sensitivityHor = 6.0f;
    public static float sensitivityVert = 6.0f;

    public float minimumVert = -90.0f;
    public float maximumVert = 90.0f;

    public float offsetHor = 0f;

    private float _rotationX = 0;
	
	// Update is called once per frame
	void Update () {
        if (GameReference.freezePlayerMovement)
        {
            return;
        }
        if (axes == RotationAxes.MouseX)
        {
            //horizontal rotation here
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            //vertical rotation here
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else
        {
            // both horizontal and vertical rotation here
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }

    }

    public static void SetSensitivity(Slider slider)
    {
        sensitivityHor = slider.value;
        sensitivityVert = slider.value;
    }
}
