using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    private float happiness = 0;
    private float happinessStep = 0.01f;

    private float zSpeed = 0.05f;
    private GameObject backgroundGradient;

    // Start is called before the first frame update
    void Start()
    {
        this.backgroundGradient = GameObject.Find("BackgroundGradient");
    }

    // Update is called once per frame
    void Update()
    {
        /* TODO deprecated */
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.ChangeHappiness(true);
            print("HAPPINESS: " + this.happiness);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.ChangeHappiness(false);
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
            this.backgroundGradient.transform.position = new Vector3(
                this.backgroundGradient.transform.position.x,
                this.backgroundGradient.transform.position.y - this.happinessStep * 1000,
                this.backgroundGradient.transform.position.z
            );
        }
        else
        {
            this.happiness -= this.happinessStep;
            this.backgroundGradient.transform.position = new Vector3(
            this.backgroundGradient.transform.position.x,
            this.backgroundGradient.transform.position.y + this.happinessStep * 1000,
            this.backgroundGradient.transform.position.z
        );
        }
    }
}
