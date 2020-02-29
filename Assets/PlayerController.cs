using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float jumpHeight = 4f;
    private Transform cameraTransform;
    private bool jumping = false;

    private float playerPositionY = -100f;

    private float zDistanceToCamera = 3f;

    // Start is called before the first frame update
    void Start()
    {
      this.cameraTransform = GameObject.Find("Main Camera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
          if(transform.position.y <= playerPositionY)
          {
            jumping = true;
          }
        }

        if (transform.position.y > playerPositionY + jumpHeight)
        {
          print("jump off");
          jumping = false;
        }

        if (jumping)
        {
          if(transform.position.y < playerPositionY + jumpHeight){
            print("jumping");
            transform.position = new Vector3(
              transform.position.x,
              transform.position.y + 0.1f,
              cameraTransform.position.z - zDistanceToCamera
            );
          }
        } else {
          if (transform.position.y < playerPositionY){
            print("2222");
            transform.position = new Vector3(
              transform.position.x,
              transform.position.y + 0.05f,
              cameraTransform.position.z - zDistanceToCamera
            );
          } else{
            print("3333");
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y - 0.05f,
                cameraTransform.position.z - zDistanceToCamera
              );
          }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            this.playerPositionY = other.transform.position.y + 2;
        }
    }
}
