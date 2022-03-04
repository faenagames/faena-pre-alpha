using UnityEngine;
using System.Collections;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;
    // Use this for initialization
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
        Ray ray = _camera.ScreenPointToRay(point);
        RaycastHit hitObject;


        //this is only enabled when we want to see the context text in the center of screen
        GameReference.self.AimPopup.SetActive(false);

        //Shoot a ray each frame
        if (!GameReference.freezePlayerMovement && Physics.Raycast(ray, out hitObject))
        {
            ReactiveTarget rt = hitObject.transform.gameObject.GetComponent<ReactiveTarget>();
            if (rt != null)
            {
                rt.OnRayHit();
                GameReference.self.AimPopup.SetActive(true);
                GameReference.self.AimPopupText.text = rt.popupText;
            }

            //On click, say what was hit by the ray.
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("You hit " + hitObject.transform.gameObject.ToString());
                if (rt != null)
                {
                    rt.OnRayClick();
                }
            }
        }
    }
}