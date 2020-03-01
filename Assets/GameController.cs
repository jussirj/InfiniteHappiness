using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private float winLimit = 1f;
    private float loseLimit = -1f;
    private float happiness = 0f;

    private GameObject winScreen;
    private GameObject loseScreen;
    private GameObject introCanvas;
    private GameObject gameOverSound;
    private GameObject gameWonSound;
    private GameObject backgroundMusic;

    private FloorSpawner floorSpawner;
    private PlayerController player;
    private Cub cub;
    private PointSpawner pointSpawner;
    private Camera camera;

    private bool gameEnd = false;
    private bool startScreen = true;

    // Start is called before the first frame update
    void Awake()
    {
        this.winScreen = GameObject.Find("WinScreen");
        this.loseScreen = GameObject.Find("LoseScreen");
        this.introCanvas = GameObject.Find("IntroCanvas");
        this.winScreen.SetActive(false);
        this.loseScreen.SetActive(false);
        this.cub = GameObject.Find("Cub").GetComponent<Cub>();
        this.floorSpawner = GameObject.Find("FloorSpawner").GetComponent<FloorSpawner>();
        this.player = GameObject.Find("Player").GetComponent<PlayerController>();
        this.pointSpawner = GameObject.Find("PointSpawner").GetComponent<PointSpawner>();
        this.camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        this.gameOverSound = GameObject.Find("game_over");
        this.gameWonSound = GameObject.Find("game_won");
        this.backgroundMusic = GameObject.Find("Audio Source");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.floorSpawner.GetLastFloor())
        {
            this.happiness = this.floorSpawner.GetHappiness();
            if (this.happiness <= loseLimit || this.player.transform.position.y < (this.floorSpawner.GetLastFloor().transform.position.y - 20f))
            {
                this.loseScreen.SetActive(true);
                this.cub.Stop();
                this.player.Stop();
                this.pointSpawner.Reset();
                if(this.gameEnd == false) {
                    this.gameOverSound.GetComponent<AudioSource>().Play();
                    this.backgroundMusic.GetComponent<AudioSource>().Stop();
                }
                this.gameEnd = true;
            }

            if (this.happiness >= winLimit)
            {
                this.winScreen.SetActive(true);
                this.cub.Stop();
                this.player.Stop();
                this.pointSpawner.Reset();

                if(this.gameEnd == false)
                {
                  this.gameWonSound.GetComponent<AudioSource>().Play();
                  this.backgroundMusic.GetComponent<AudioSource>().Stop();
                }
                this.gameEnd = true;
            }

            if (startScreen && Input.GetKey(KeyCode.Space))
            {
                this.pointSpawner.Play();
                this.startScreen = false;
                this.introCanvas.SetActive(false);
                this.floorSpawner.SetRandomEnabled(true);
            }

            if (gameEnd && Input.GetKey(KeyCode.R))
            {
                this.winScreen.SetActive(false);
                this.loseScreen.SetActive(false);
                this.player.Reset();
                this.floorSpawner.Reset();
                this.camera.Reset();
                this.gameEnd = false;
                this.cub.Play();
                this.player.Play();
                this.pointSpawner.Play();
                this.startScreen = true;
                this.backgroundMusic.GetComponent<AudioSource>().Play();
            }
        }
    }
}
