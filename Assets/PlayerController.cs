using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    private Transform cameraTransform;
    //private Rigidbody rb;

    private float targetY = -100f;

    private float zDistanceToCamera = 3f;

    // Start is called before the first frame update
    void Start()
    {
      this.cameraTransform = GameObject.Find("Main Camera").transform;
      //this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //this.rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }

        if (transform.position.y < targetY)
        {
           transform.position = new Vector3(
              transform.position.x,
              transform.position.y + 0.05f,
              cameraTransform.position.z - zDistanceToCamera
            );
        } else
        {
            transform.position = new Vector3(
               transform.position.x,
               transform.position.y - 0.05f,
               cameraTransform.position.z - zDistanceToCamera
             );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            this.targetY = other.transform.position.y + 2;
        }
    }
}
