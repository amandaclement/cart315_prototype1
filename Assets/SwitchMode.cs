using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchMode : MonoBehaviour
{
    public void switchMode(string regularMode)
    {
        SceneManager.LoadScene(regularMode);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
