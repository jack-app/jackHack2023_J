using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ugoki : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(1,0,0); 
    }
    private void OnBecameVisible() {
        Debug.Log("visible");
    }
}
