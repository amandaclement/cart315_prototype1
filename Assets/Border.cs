using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// reference: https://answers.unity.com/questions/1166144/how-do-i-rotate-an-object-90-or-90-degrees-upon-co.html
// reference for plane rotation: https://forum.unity.com/threads/how-to-rotate-an-object-over-time-using-c.448895/

public class Border : MonoBehaviour
{
    public GameObject Player;
    public GameObject Plane;

    public Vector3 rotationDirection;
    public float smoothTime;
    private float convertedTime = 200;
    private float smooth;

    bool rotating = false; // boolean to check if rotation is already occurring
    //public float smoothTime = 0.5f; // rotation speed

    public Vector3 rotation = new Vector3(0, 50f, 0); // this is a constructor

    public float totalRotationTime = 55f;

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.gameObject == Player && !rotating)
    //    {

    //        rotating = true;
    //        float rando = Random.Range(0, 100); // pick a random number between 1 and 100
    //        int multiplier = 10;
    //        if (rando > 50)
    //        {
    //            multiplier = -1;
    //        }
    //        StartCoroutine(RotateOverTime(Plane.transform.localEulerAngles.x, Plane.transform.localEulerAngles.x + (180 * multiplier), smoothTime));
    //    }
    //}
    //IEnumerator RotateOverTime(float currentRotation, float desiredRotation, float overTime)
    //{
    //    float i = 0.0f;
    //    while (i <= 1)
    //    {
    //        Plane.transform.localEulerAngles = new Vector3(Mathf.Lerp(currentRotation, desiredRotation, i), Plane.transform.localEulerAngles.y, Plane.transform.localEulerAngles.z);
    ////        //Plane.transform.localEulerAngles = new Vector3(Plane.transform.localEulerAngles.y, Mathf.Lerp(currentRotation, desiredRotation, i), Plane.transform.localEulerAngles.z);
    ////       // Plane.transform.rotation = currentRotation * Quaternion.Euler(desiredRotation, desiredRotation, desiredRotation);
    //        i += Time.deltaTime / overTime;
    //        yield return null;
    //    }
    ////    yield return new WaitForSeconds(overTime);
    //    rotating = false; // no longer rotating
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("should be rotating");
        //rotating = true;
        //var degreesPerSecond = Plane.transform.eulerAngles.y / totalRotationTime;
        //Plane.transform.Rotate(new Vector3(0, degreesPerSecond * Time.deltaTime, 0));

        smooth = Time.deltaTime * smoothTime * convertedTime;
        Plane.transform.Rotate(rotationDirection * smooth);
         }
    }
}
