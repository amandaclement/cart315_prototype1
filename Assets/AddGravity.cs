using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// adding gravity to rigibody platforms once player is above/on them

public class AddGravity : MonoBehaviour
{
    // reference: https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html?_ga=2.125981838.2057613814.1612463807-1308570294.1603245419
    // detecting which plane the player is closest to figure out which one to flip (on double jump)
    public GameObject FindClosestPlane()
    {
        GameObject[] planes;
        planes = GameObject.FindGameObjectsWithTag("Plane");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject plane in planes)
        {
            Vector3 diff = plane.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = plane;
                distance = curDistance;
            }
        }
        return closest;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FindClosestPlane().GetComponent<Rigidbody>().useGravity = true; // adding gravity
    }
}
