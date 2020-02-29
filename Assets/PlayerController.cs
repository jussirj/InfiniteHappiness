using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float jumpHeight = 4f;
    private Transform cameraTransform;
    private bool jumping = false;
    private Camera cameraScript;

    private float playerPositionY = -100f;

    private float zDistanceToCamera = 3f;

    // Start is called before the first frame update
    void Start()
    {
        this.cameraTransform = GameObject.Find("Main Camera").transform;
        this.cameraScript = GameObject.Find("Main Camera").GetComponent<Camera>();
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
          jumping = false;
        }

        if (jumping)
        {
          if(transform.position.y < playerPositionY + jumpHeight) {
            transform.position = new Vector3(
              transform.position.x,
              transform.position.y + 0.1f,
              cameraTransform.position.z - zDistanceToCamera
            );
          }
        } else {
          if (transform.position.y < playerPositionY){
            transform.position = new Vector3(
              transform.position.x,
              transform.position.y + 0.05f,
              cameraTransform.position.z - zDistanceToCamera
            );
          } else {
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
        if (other.gameObject.tag == "PlusPoint")
        {
            other.gameObject.SetActive(false);
            this.cameraScript.ChangeHappiness(true);
        }
        if (other.gameObject.tag == "MinusPoint")
        {
            other.gameObject.SetActive(false);
            this.cameraScript.ChangeHappiness(false);
        }
    }
}
