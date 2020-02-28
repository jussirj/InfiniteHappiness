using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    private Transform cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
      this.cameraTransform = GameObject.Find("Main Camera").transform;
    }

    // Update is called once per frame
    void Update()
    {
          transform.position = new Vector3(
          transform.position.x,
          transform.position.y,
          cameraTransform.position.z
        );


    }


}

