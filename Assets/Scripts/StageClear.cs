using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Stage Clear");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.Space)) {
            SceneManager.LoadScene("ayu_stage2");
        }
    }
}
