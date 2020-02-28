using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cub : MonoBehaviour
{
    Movin cub;

    void Start()
    {

        cub = new Movin(transform, "json/cub");
        Debug.Log(cub);
        cub.Play();
    }

    void Update()
    {

    }

}
