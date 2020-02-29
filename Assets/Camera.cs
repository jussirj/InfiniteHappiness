using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    private float happiness = 0;
    private float happinessStep = 0.01f;

    private float zSpeed = 0.05f;

    private Transform PlayerStopperTransform;

    // Start is called before the first frame update
    void Start()
    {
        this.PlayerStopperTransform = GameObject.Find("PlayerStopper").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.happiness += this.happinessStep;
            print("HAPPINESS: " + this.happiness);
            /*
            this.PlayerStopperTransform.localPosition = new Vector3(
                this.PlayerStopperTransform.localPosition.x,
                -5.5f,
                this.PlayerStopperTransform.localPosition.z
            );
            */
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.happiness -= this.happinessStep;
            print("HAPPINESS: " + this.happiness);
            /*
            if (this.PlayerStopperTransform.localPosition.y < -1.5f)
            {
                this.PlayerStopperTransform.localPosition = new Vector3(
                this.PlayerStopperTransform.localPosition.x,
                this.PlayerStopperTransform.localPosition.y + 0.07f,
                this.PlayerStopperTransform.localPosition.z
            );
            }
            */
        }

        transform.position = new Vector3(
            transform.position.x,
            transform.position.y + happiness,
            transform.position.z + zSpeed
        );
    }
}
