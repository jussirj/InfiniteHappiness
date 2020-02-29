using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientLight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.ambientGroundColor = new Color32(160, 144, 224, 255);
        RenderSettings.ambientEquatorColor = new Color32(250, 160, 192, 255);
        RenderSettings.ambientSkyColor = new Color32(255, 224, 0, 255);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
