using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// making platform shake
// reference: https://forum.unity.com/threads/shake-an-object-from-script.138382/

public class Shake : MonoBehaviour
{
    public float speed = 1.0f; // shake speed
    public float amount = 1.0f; // shake intensity

    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition.x = transform.position.x;
        startPosition.y = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        // shake values (shake only affects y axis)
        float x = transform.position.x;
        float y = Mathf.Sin(Time.time * speed) * amount;
        float z = transform.position.z;

        this.transform.position = new Vector3(x, y, z);
    }
}
