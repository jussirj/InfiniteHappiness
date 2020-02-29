using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float jumpHeight = 4f;
    private bool jumping = false;
    private FloorSpawner floorSpawner;

    private float playerPositionY = -100f;

    private float zSpeed = 0.1f;

    private bool stopped = false;

    // Start is called before the first frame update
    void Start()
    {
        this.floorSpawner = GameObject.Find("FloorSpawner").GetComponent<FloorSpawner>();
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



        if(!stopped){
          if (jumping)
          {
            if(transform.position.y < playerPositionY + jumpHeight) {
              transform.position = new Vector3(
                transform.position.x,
                transform.position.y + 0.1f,
                transform.position.z + this.zSpeed
              );
            }
          } else {
            if (transform.position.y < playerPositionY){
              transform.position = new Vector3(
                transform.position.x,
                transform.position.y + 0.05f,
                transform.position.z + this.zSpeed
              );
            } else {
              transform.position = new Vector3(
                  transform.position.x,
                  transform.position.y - 0.05f,
                  transform.position.z + this.zSpeed
                );
            }
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
            this.floorSpawner.ChangeHappiness(true);
        }
        if (other.gameObject.tag == "MinusPoint")
        {
            other.gameObject.SetActive(false);
            this.floorSpawner.ChangeHappiness(false);
        }
    }

    public void Stop()
    {
        this.stopped = true;
    }
}
