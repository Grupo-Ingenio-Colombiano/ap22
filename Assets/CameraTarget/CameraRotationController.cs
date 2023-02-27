using UnityEngine;

public class CameraRotationController : MonoBehaviour
{
    public float sensX = 100.0f;
    public float sensY = 100.0f;

    float rotationY = 0.0f;
    float rotationX = 0.0f;

    Vector3 initRot;

    private void Awake()
    {
        initRot = transform.localEulerAngles;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            rotationX += Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
            rotationY += Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;
            rotationY = Mathf.Clamp(rotationY, -45f, 45f);
            rotationX = Mathf.Clamp(rotationX, -90f, 90f);
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }

        if (Input.GetMouseButtonUp(1))
        {
            rotationX = 0f;
            rotationY = 0f;

            transform.localEulerAngles = initRot;
        }

    }

}
