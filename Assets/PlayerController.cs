using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private FloorSpawner floorSpawner;

    private bool stopped = false;

    private Vector3 initialPosition;

    private GameObject eatNegativeSound;
    private GameObject eatPositiveSound;

    private List<GameObject> barkSounds = new List<GameObject>();

    private Vector3 nextFloorPosition;
    private float jumpTime = 0;
    
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
        this.nextFloorPosition = new Vector3(0, -1000, 1000);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            this.jumpTime = Time.realtimeSinceStartup + 0.4f;
            nextFloorPosition = new Vector3(0, -1000, 1500);
        }

        if (!stopped)
        {
            if (Time.realtimeSinceStartup < this.jumpTime)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 1000, 1500), 0.15f);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, nextFloorPosition + Vector3.down * 5, 0.15f);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            this.nextFloorPosition = other.transform.position;
        }
        if (other.gameObject.tag == "Hole")
        {
            this.nextFloorPosition = new Vector3(0, -1000, 1000);
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

    public void Stop()
    {
        this.stopped = true;
    }

    public void Reset()
    {
        transform.position = this.initialPosition;
        this.nextFloorPosition = new Vector3(0, -300, 1000);
        this.stopped = false;
    }
}
