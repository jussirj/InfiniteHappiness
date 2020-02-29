using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject backgroundGradient;
    private GameObject player;

    private float targetY;
    private float distanceToPlayerY = 20f;
    private float distanceToPlayerZ = 10f;
    private float distanceToPlayerYThreshold = 0.5f;
    private Vector3 initialCameraPosition;
    private Vector3 initialBackgroundPosition;

    // Start is called before the first frame update
    void Start()
    {
        this.backgroundGradient = GameObject.Find("BackgroundGradient");
        this.player = GameObject.Find("Player");
        this.targetY = this.player.transform.position.y + this.distanceToPlayerY;
        this.initialCameraPosition = transform.position;
        UpdateBackground(0);
        this.initialBackgroundPosition = this.backgroundGradient.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > this.targetY + this.distanceToPlayerYThreshold)
        {
            transform.position = new Vector3(
               transform.position.x,
               transform.position.y - 0.05f,
               this.player.transform.position.z + this.distanceToPlayerZ
           );
        } else if (transform.position.y < this.targetY - this.distanceToPlayerYThreshold)
        {
           transform.position = new Vector3(
               transform.position.x,
               transform.position.y + 0.05f,
               this.player.transform.position.z + this.distanceToPlayerZ
           );
        } else
        {
            transform.position = new Vector3(
               transform.position.x,
               transform.position.y,
               this.player.transform.position.z + this.distanceToPlayerZ
           );
        }
        this.targetY = this.player.transform.position.y + this.distanceToPlayerY;
    }

    public void UpdateBackground(float happiness)
    {
        this.backgroundGradient.transform.position = new Vector3(
            this.backgroundGradient.transform.position.x,
            this.backgroundGradient.transform.position.y - happiness * 50f,
            this.backgroundGradient.transform.position.z
        );
    }

    public void Reset()
    {
        transform.position = this.initialCameraPosition;
        this.backgroundGradient.transform.position = initialBackgroundPosition;
    }
}
