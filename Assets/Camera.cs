using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    private bool happiness = false;

    private float ySpeed = 0.02f;
    private float zSpeed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            happiness = true;
        }
        else
        {
            happiness = false;
        }
        float positionY = happiness ? transform.position.y + ySpeed : transform.position.y - ySpeed;
        transform.position = new Vector3(transform.position.x, positionY, transform.position.z + zSpeed);
    }
}
