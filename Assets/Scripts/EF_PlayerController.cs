using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EF_PlayerController : MonoBehaviour
{
    Rigidbody rbody;
    InputAction playAction;
    Vector2 mousePosition;

    public Camera mainCamera;
    public GameObject targetObject;
    public float objectSpeed = 5.0f;
    public float mouseSensitivity = 2.0f;

    float sensitivityX = 600;
    float sensitivityY = 600;
    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        rbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        mainCamera = GetComponentInChildren<Camera>();

        playAction = GetComponent<PlayerInput>().actions.FindAction("Move");
        playAction.Enable();

        Cursor.lockState = CursorLockMode.Locked;
    
    }

    // Update is called once per frame
    void Update()
    {
        cameraRay();
    }

    void FixedUpdate()
    {
        Vector2 inputVector = playAction.ReadValue<Vector2>();

        if (inputVector == new Vector2(0.0f, 0.0f))
        {
            rbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            transform.position += (mainCamera.transform.forward * inputVector.y * objectSpeed * Time.fixedDeltaTime) + (mainCamera.transform.right * inputVector.x * objectSpeed * Time.fixedDeltaTime);
            transform.position = new Vector3(transform.position.x, 0.8f, transform.position.z);
        }

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * sensitivityX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * sensitivityY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -60f, 100f);

        transform.rotation = Quaternion.Euler(0, xRotation, 0);
        mainCamera.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }

    public Vector2 GetMousePosition()
    {
        return mousePosition;
    }

    public void OnMouse(InputValue mousePos)
    {
        mousePosition = mousePos.Get<Vector2>();
    }

    public GameObject getTargetObject()
    {
        return targetObject;
    }

    void cameraRay()
    {
        int layerMask = 1 << LayerMask.NameToLayer("Interactable");

        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //middle of screen
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);

        if(Physics.Raycast(ray, out RaycastHit hit, 10, layerMask))
        {
            targetObject = GameObject.Find(hit.collider.transform.gameObject.name);
        }
        else
        {
            targetObject = null;
        }
    }
}
