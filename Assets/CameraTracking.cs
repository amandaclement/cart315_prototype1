using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.GetComponent<Transform>().LookAt(player.transform);

        // alpha 1 key to move camera up
        if (Input.GetKey(KeyCode.Alpha1))
        {
            this.transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }

        // Q key to move camera down
        if (Input.GetKey(KeyCode.Q))
        {
            this.transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        }
    }
}
