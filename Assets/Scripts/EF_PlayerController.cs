using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EF_PlayerController : MonoBehaviour
{
    Rigidbody rbody;
    InputAction moveAction;
    //InputAction clickAction;
    Vector2 mousePosition;

    public Camera mainCamera;
    public GameObject targetObject;
    public float objectSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        rbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        moveAction = GetComponent<PlayerInput>().actions.FindAction("Move");
        moveAction.Enable();
        //clickAction = GetComponent<PlayerInput>().actions.FindAction("Click Item");
        //clickAction.Enable();
        
        mainCamera = GetComponentInChildren<Camera>();

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        cameraRay();
    }

    void FixedUpdate()
    {
        Vector2 inputVector = moveAction.ReadValue<Vector2>();

        if (inputVector == new Vector2(0.0f, 0.0f))
        {
            rbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ 
                | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }
        else
        {
            rbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            transform.position += (mainCamera.transform.forward * inputVector.y * objectSpeed * Time.fixedDeltaTime) 
                + (mainCamera.transform.right * inputVector.x * objectSpeed * Time.fixedDeltaTime);
            transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
        }
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

    public void OnClickItem()
    {
        if (targetObject != null)
        {
            targetObject.SendMessage("OnInteract");
        }
        else
        {
            Debug.Log("Null target object" + targetObject);
        }

        Debug.Log("Item Clicked");
    }

    void cameraRay()
    {
        int layerMask = 1 << LayerMask.NameToLayer("Interactable");

        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //middle of screen
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);

        if(Physics.Raycast(ray, out RaycastHit hit, 10, layerMask))
        {
            targetObject = GameObject.Find(hit.collider.transform.gameObject.name);
            Debug.Log(targetObject);
        }
        else
        {
            targetObject = null;
        }
    }
}
