using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// making the platform move up and down (on y-axis) continuously over set time intervals
public class YMovement : MonoBehaviour
{
    public float speed; // speed of movement
    public float max1; // first limit
    public float max2; // second limit

    private int direction = 1; // movement direction

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(0, moveVertical); // moving platform across y axis

        if (transform.position.x > max1)
        {
            direction = -1;
        }
        else if (transform.position.x < max2)
        {
            direction = 1;
        }
        movement = Vector3.up * direction * speed * Time.deltaTime;
        transform.Translate(movement);

    }
}
