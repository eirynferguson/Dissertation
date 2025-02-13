using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EF_CameraController : MonoBehaviour
{
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //moves camera with player
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 0.8f, target.transform.position.z);
    }
}
