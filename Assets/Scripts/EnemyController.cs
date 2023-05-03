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
        fishComponent.Move((target.transform.position - transform.position)*speed* Time.deltaTime * Random.Range(-0.1f, 1f)); // 索敵
    }

    // 当たり判定
    void OnCollisionEnter(Collision collision)
    {
      Debug.Log("Hit"); // ログを表示する
    }
}
