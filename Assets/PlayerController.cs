using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    private Transform cameraTransform;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
      this.cameraTransform = GameObject.Find("Main Camera").transform;
      this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.cameraTransform.position.y - transform.position.y > 3)
        {
            transform.position = new Vector3(transform.position.x, this.cameraTransform.position.y - 3, transform.position.z);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            this.rb.AddForce(Vector3.up * 0.2f, ForceMode.Impulse);
        }

            transform.position = new Vector3(
          transform.position.x,
          transform.position.y,
          cameraTransform.position.z
        );


    }


}

