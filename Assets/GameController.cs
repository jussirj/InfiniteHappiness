﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private float winLimit = 1.5f;
    private float loseLimit = -1.5f;
    private float happiness = 0f;

    private GameObject winScreen;
    private GameObject loseScreen;
    private GameObject introCanvas;

    private FloorSpawner floorSpawner;
    private PlayerController player;
    private Cub cub;
    private PointSpawner pointSpawner;
    private Camera camera;

    private bool gameEnd = false;
    private bool startScreen = true;

    // Start is called before the first frame update
    void Start()
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
            this.gameEnd = true;
            this.pointSpawner.Reset();
        }

        if (this.happiness >= winLimit)
        {
            this.winScreen.SetActive(true);
            this.cub.Stop();
            this.player.Stop();
            this.gameEnd = true;
            this.pointSpawner.Reset();
        }

        if (startScreen && Input.GetKey(KeyCode.Space))
        {
            this.pointSpawner.Play();
            this.startScreen = false;
            this.introCanvas.SetActive(false);
        }

        if (gameEnd && Input.GetKey(KeyCode.Space))
        {
            this.winScreen.SetActive(false);
            this.loseScreen.SetActive(false);
            this.player.Reset();
            this.floorSpawner.Reset();
            this.camera.Reset();
            this.gameEnd = false;
            this.cub.Play();
            this.player.Start();
            this.pointSpawner.Play();
            this.startScreen = true;
        }
    }
}
