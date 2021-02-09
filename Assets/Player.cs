using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// reference (character controller tutorial): https://www.youtube.com/watch?v=59No0ybIoxg

public class Player : MonoBehaviour
{
    [SerializeField] // used so that variable cannot be changed by other scripts
    private float moveSpeed = 5f;
    [SerializeField]
    private float gravity = 9.81f;
    [SerializeField]
    private float jumpSpeed = 3.5f;
    [SerializeField]
    private float doubleJumpMultiplier = 0.5f;

    private CharacterController controller;

    private float directionY;

    private bool canDoubleJump = false;

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
        controller = GetComponent<CharacterController>();
    }

    // reference: https://answers.unity.com/questions/1202034/smooth-90-degree-rotation-on-keypress.html
    // handling the rotation (flip) of the plane
    IEnumerator RotatePlane(Vector3 byAngles, float inTime)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            FindClosestPlane().transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);

        if (controller.isGrounded)
        {
            canDoubleJump = true; // enable double jump

            if (Input.GetButton("Jump")) // for some reason this doesn't work properly using GetButtonDown
            {
                directionY = jumpSpeed;
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump") && canDoubleJump) // for some reason this only really works with GetButtonDown
            {
                Debug.Log("double jump");
                directionY = jumpSpeed * doubleJumpMultiplier;
                canDoubleJump = false;

                // flipping plane on double jump
                StartCoroutine(RotatePlane(Vector3.left * 180, 0.2f));
            }
        }

        directionY -= gravity * Time.deltaTime;
        direction.y = directionY;
        controller.Move(direction * moveSpeed * Time.deltaTime);
    }
}
