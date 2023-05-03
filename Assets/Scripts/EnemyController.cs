// 敵の動き
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject target;
    FishComponent fishComponent;
    // Start is called before the first frame update
    void Start()
    {
     fishComponent = gameObject.GetComponent<FishComponent>();  
    }

    // Update is called once per frame
    public float speed;
    void Update()
    {
        fishComponent.Move((target.transform.position - transform.position)*speed* Time.deltaTime); // 索敵
    }
}
