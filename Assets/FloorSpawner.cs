using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{

    private Transform cameraTransform;
    private GameObject floor;

    private float distanceToCamera = 1f;
    private float distanceToCameraY = 10f;
    private float zSpeed = 1f;

    private int floorAmount = 20;
    private List<GameObject> floors = new List<GameObject>();
    private int floorIndex = 0;

    private GameObject lastFloor;

    // Start is called before the first frame update
    void Start()
    {
        this.cameraTransform = GameObject.Find("Main Camera").transform;
        this.floor = GameObject.Find("Cube");
        InstantiateFloors();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z - this.cameraTransform.position.z < distanceToCamera)
        {
            transform.position = new Vector3(transform.position.x, this.cameraTransform.position.y - distanceToCameraY, transform.position.z + zSpeed);
            SpawnFloor();
        }
            
    }

    void InstantiateFloors()
    {
        for (int i = 0; i < this.floorAmount; ++i)
        {
            GameObject floor = GameObject.Instantiate(this.floor);
            floor.SetActive(false);
            floors.Add(floor);
        }
        this.floor.SetActive(false);
        floors.Add(this.floor);
    }

    void SpawnFloor()
    {
        if (this.floorIndex > this.floors.Count - 1)
        {
            this.floorIndex = 0;
        }
        GameObject floor = this.floors[this.floorIndex];
        floor.transform.position = transform.position;
        floor.SetActive(true);
        this.floorIndex++;
        this.lastFloor = floor;
    }

    public GameObject GetLastFloor()
    {
        return this.lastFloor;
    }
}
