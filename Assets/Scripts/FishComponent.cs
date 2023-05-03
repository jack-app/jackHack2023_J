using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishComponent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Move(Vector3 vec)
    {
        transform.position += vec;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
