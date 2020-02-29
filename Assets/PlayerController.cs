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

    private Vector3 initialPosition;

    private GameObject eatNegativeSound;
    private GameObject eatPositiveSound;

    private List<GameObject> barkSounds = new List<GameObject>();

    // Start is called before the first frame update
    public void Start()
    {
        this.floorSpawner = GameObject.Find("FloorSpawner").GetComponent<FloorSpawner>();
        this.barkSounds.Add(GameObject.Find("cub_bark_1"));
        this.barkSounds.Add(GameObject.Find("cub_bark_2"));
        this.barkSounds.Add(GameObject.Find("cub_bark_3"));
        this.eatNegativeSound = GameObject.Find("cub_eat_chili");
        this.eatPositiveSound = GameObject.Find("cub_eat_candy");
        this.initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            if (transform.position.y <= playerPositionY)
            {
                jumping = true;
                this.barkSounds[Mathf.RoundToInt(Random.Range(0, 2))].GetComponent<AudioSource>().Play();
            }
        }

        if (transform.position.y > playerPositionY + jumpHeight)
        {
            jumping = false;
        }



        if (!stopped)
        {
            if (jumping)
            {
                if (transform.position.y < playerPositionY + jumpHeight)
                {
                    transform.position = new Vector3(
                      transform.position.x,
                      transform.position.y + 0.1f,
                      transform.position.z + this.zSpeed
                    );
                }
            }
            else
            {
                if (transform.position.y < playerPositionY)
                {
                    transform.position = new Vector3(
                      transform.position.x,
                      transform.position.y + 0.05f,
                      transform.position.z + this.zSpeed
                    );
                }
                else
                {
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
            this.playerPositionY = other.transform.position.y - 5;
        }
        if (other.gameObject.tag == "PlusPoint")
        {
            other.gameObject.SetActive(false);
            this.floorSpawner.ChangeHappiness(true);
            this.eatPositiveSound.GetComponent<AudioSource>().Play();
        }
        if (other.gameObject.tag == "MinusPoint")
        {
            other.gameObject.SetActive(false);
            this.floorSpawner.ChangeHappiness(false);
            this.eatNegativeSound.GetComponent<AudioSource>().Play();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (!this.jumping && other.gameObject.tag == "Floor")
        {
            this.playerPositionY = -5000f;
        }
    }

    public void Stop()
    {
        this.stopped = true;
    }

    public void Reset()
    {
        transform.position = this.initialPosition;
        this.stopped = false;
    }
}
