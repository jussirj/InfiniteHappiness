using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject backgroundGradient;
    private GameObject player;

    private float targetY;

    // Start is called before the first frame update
    void Start()
    {
        this.backgroundGradient = GameObject.Find("BackgroundGradient");
        this.player = GameObject.Find("Player");
        this.targetY = this.player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            transform.position.x,
            this.player.transform.position.y + 10f,
            this.player.transform.position.z + 5f
        );
    }

    public void UpdateBackground(float happiness)
    {
        this.backgroundGradient.transform.position = new Vector3(
            this.backgroundGradient.transform.position.x,
            this.backgroundGradient.transform.position.y - happiness * 50f,
            this.backgroundGradient.transform.position.z
        );
    }
}
