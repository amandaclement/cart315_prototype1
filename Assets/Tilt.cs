using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// resource: https://forum.unity.com/threads/tilt-floor-based-on-players-position.383548/

public class Tilt : MonoBehaviour
{
    public Transform player;
    public GameObject target;

    public float sensitivity = 3f;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void FixedUpdate()
    {
            Vector3 diff = (player.position - transform.position).normalized;
            diff *= sensitivity;
            diff.y = 1;
            Quaternion target = Quaternion.FromToRotation(transform.up, diff);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime);
    }
}
