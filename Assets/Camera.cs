using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    private float happiness = 0;
    private float happinessStep = 0.01f;

    private float zSpeed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        /* TODO deprecated */
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.happiness += this.happinessStep;
            print("HAPPINESS: " + this.happiness);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.happiness -= this.happinessStep;
            print("HAPPINESS: " + this.happiness);
        }

        transform.position = new Vector3(
            transform.position.x,
            transform.position.y + happiness,
            transform.position.z + zSpeed
        );
    }

    public void ChangeHappiness(bool happiness)
    {
        if (happiness)
        {
            this.happiness += this.happinessStep;
        } else
        {
            this.happiness -= this.happinessStep;
        }
    }
}
