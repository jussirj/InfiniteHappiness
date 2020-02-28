using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    private bool happiness = false;

    private float ySpeed = 0.02f;
    private float zSpeed = 0.05f;

    private Transform PlayerStopperTransform;

    // Start is called before the first frame update
    void Start()
    {
        this.PlayerStopperTransform = GameObject.Find("PlayerStopper").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            happiness = true;
            this.PlayerStopperTransform.localPosition = new Vector3(
                this.PlayerStopperTransform.localPosition.x,
                -5.5f,
                this.PlayerStopperTransform.localPosition.z
            );
        }
        else
        {
            happiness = false;
            if (this.PlayerStopperTransform.localPosition.y < -1.5f)
            {
                this.PlayerStopperTransform.localPosition = new Vector3(
                this.PlayerStopperTransform.localPosition.x,
                this.PlayerStopperTransform.localPosition.y + 0.07f,
                this.PlayerStopperTransform.localPosition.z
            );
            }
        }
        float positionY = happiness ? transform.position.y + ySpeed : transform.position.y - ySpeed;
        transform.position = new Vector3(transform.position.x, positionY, transform.position.z + zSpeed);
    }
}
