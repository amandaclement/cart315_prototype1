using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    public Camera mainCamera;
    public Camera secondaryCamera;

    public GameObject player;
    public float moveSpeed;

    // using main (player) camera
    public void playerView()
    {
        mainCamera.enabled = true;
        secondaryCamera.enabled = false;
    }

    // showing scene overhead (enabling secondary camera)
    public void ShowOverheadView()
    {
        mainCamera.enabled = false;
        secondaryCamera.enabled = true;
    }

    // pausing/resuming game by setting timeScale to 0/1 respectively (to be used during camera overview)
    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerView(); // playerView is default
    }

    // Update is called once per frame
    void Update() // using Update instead of FixedUpdate since Fixed Update can run >= 0 times per frame, so getting an up/down key during can be unreliable
    {
        mainCamera.GetComponent<Transform>().LookAt(player.transform); // follow player

        //// alpha 1 key to move main camera up
        //if (Input.GetKey(KeyCode.Alpha1))
        //{
        //    mainCamera.transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        //}

        //// Q key to move main camera down
        //if (Input.GetKey(KeyCode.Q))
        //{
        //    mainCamera.transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        //}

        // hold E to pause game and trigger overview (secondary camera)
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key was pressed.");
            ShowOverheadView(); // show overhead (secondary camera) view
            PauseGame(); // pause game

            // camera overview
            //this.transform.rotation = Quaternion.Euler(90, 0, 0); // camera rotation
            //this.transform.position = new Vector3(0, 70, -50); // display game overview
        }

        // release E to resume game and return to mainCamera view
        else if (Input.GetKeyUp(KeyCode.E))
        {
            Debug.Log("E key was released.");

            // default (start) values
            //this.transform.rotation = Quaternion.Euler(29, 0, 0); // camera rotation
            //this.transform.position = new Vector3(0, 5, -9); // camera position
            playerView(); // return to main camera (primary) view
            ResumeGame(); // resume game
        }
    }
}
