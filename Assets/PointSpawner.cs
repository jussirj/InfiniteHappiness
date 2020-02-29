using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawner : MonoBehaviour
{
    private FloorSpawner floorSpawner;
    private Transform playerTransform;
    private GameObject plusPoint;
    private GameObject minusPoint;
    private List<GameObject> plusPoints = new List<GameObject>();
    private int plusPointIndex = 0;
    private List<GameObject> minusPoints = new List<GameObject>();
    private int minusPointIndex = 0;
    private int pointAmount = 10;

    private float spawnDistanceFromPlayer = 10f;
    private Vector3 initialPosition;
    private bool canSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        this.plusPoint = GameObject.Find("PlusPoint");
        this.minusPoint = GameObject.Find("MinusPoint");
        this.InstantiatePoints();
        this.floorSpawner = GameObject.Find("FloorSpawner").GetComponent<FloorSpawner>();
        this.playerTransform = GameObject.Find("Player").transform;
        this.initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z - this.spawnDistanceFromPlayer < playerTransform.position.z)
        {
            if (this.canSpawn)
            {
                if (Random.value > 0.5f)
                {
                    SpawnPlusPoint();
                } else
                {
                    SpawnMinusPoint();
                }
            }
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y,
                transform.position.z + Random.Range(7, 10)
            );
        }
    }

    void SpawnPlusPoint()
    {
        if (plusPointIndex > plusPoints.Count - 1)
        {
            plusPointIndex = 0;
        }
        SpawnPoint(plusPointIndex, plusPoints);
        plusPointIndex++;
    }

    void SpawnMinusPoint()
    {
        if (minusPointIndex > minusPoints.Count - 1)
        {
            minusPointIndex = 0;
        }
        SpawnPoint(minusPointIndex, minusPoints);
        minusPointIndex++;
    }

    void SpawnPoint(int index, List<GameObject> points)
    {
        GameObject floor = this.floorSpawner.GetLastFloor();

        GameObject point = points[index];
        float height = Random.value > 0.5f ? 2f : 6f;
        point.transform.position = new Vector3(
            floor.transform.position.x,
            floor.transform.position.y + height,
            floor.transform.position.z
        );
        point.SetActive(true);
    }

    void InstantiatePoints()
    {
        for (int i = 0; i < this.pointAmount; ++i)
        {
            GameObject plusPoint = GameObject.Instantiate(this.plusPoint);
            plusPoint.SetActive(false);
            plusPoints.Add(plusPoint);
            plusPoints.Add(this.plusPoint);
            this.plusPoint.SetActive(false);

            GameObject minusPoint = GameObject.Instantiate(this.minusPoint);
            minusPoint.SetActive(false);
            minusPoints.Add(minusPoint);
            minusPoints.Add(this.minusPoint);
            this.minusPoint.SetActive(false);
        }
    }

    public void Reset()
    {
        this.canSpawn = false;
        transform.position = this.initialPosition;
    }

    public void Play()
    {
        this.canSpawn = true;
    }
}
