using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private float winLimit = 1.5f;
    private float loseLimit = -1.5f;
    private float happiness = 0f;

    private GameObject winScreen;
    private GameObject loseScreen;

    private FloorSpawner floorSpawner;
    private PlayerController player;
    private Cub cub;

    // Start is called before the first frame update
    void Start()
    {
        this.winScreen = GameObject.Find("WinScreen");
        this.loseScreen = GameObject.Find("LoseScreen");
        this.winScreen.SetActive(false);
        this.loseScreen.SetActive(false);
        this.cub = GameObject.Find("Cub").GetComponent<Cub>();
        this.floorSpawner = GameObject.Find("FloorSpawner").GetComponent<FloorSpawner>();
        this.player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        this.happiness = this.floorSpawner.GetHappiness();

        if (this.happiness <= loseLimit)
        {
            this.loseScreen.SetActive(true);
            this.cub.Stop();
            this.player.Stop();
        }

        if (this.happiness >= winLimit)
        {
            this.winScreen.SetActive(true);
            this.cub.Stop();
            this.player.Stop();
        }
    }
}
