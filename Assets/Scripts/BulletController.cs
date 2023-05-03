using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject target;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        velocity = (1f, 0, 0)
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity + (target.transform.position - transform.position)*0.01f);
    }
}
