using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// reference for orbit effect: https://www.youtube.com/watch?v=3PHc6vEckvc

public class Orbit : MonoBehaviour
{
    public GameObject orbitter; // the object to orbit around
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // making the planes rotate around the goal (final) platform
        transform.RotateAround(orbitter.transform.position, Vector3.up, speed * Time.deltaTime);   
    }
}
