using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float jumpHeight = 4f;
    private bool jumping = false;
    private FloorSpawner floorSpawner;
    private float startLevel = 0f;
    private float loseLimit = 30f;
    private float winLimit = 30f;
    private float playerPositionY = -100f;
    private GameObject winScreen;
    private GameObject loseScreen;
    private Cub cub;
    private bool stopped;

    private float zDistanceToCamera = 3f;
    private float zSpeed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        this.floorSpawner = GameObject.Find("FloorSpawner").GetComponent<FloorSpawner>();
        startLevel = transform.position.y;
        this.winScreen = GameObject.Find("WinScreen");
        this.loseScreen = GameObject.Find("LoseScreen");
        this.winScreen.SetActive(false);
        this.loseScreen.SetActive(false);
        this.cub = GameObject.Find("Cub").GetComponent<Cub>();
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

        if(transform.position.y < startLevel - loseLimit) {
          this.loseScreen.SetActive(true);
          this.stopped = true;
          this.cub.Stop();
        }

        if (transform.position.y > startLevel + winLimit) {
          this.winScreen.SetActive(true);
          this.stopped = true;
          this.cub.Stop();
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
}
