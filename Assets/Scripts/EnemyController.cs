// 敵の動き
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("追跡するオブジェクト")]
    public GameObject target;
    [SerializeField]
    [Tooltip("撃つ弾")]
    public GameObject bullet;
    FishComponent fishComponent;
    
    // Start is called before the first frame update
    void Start()
    {
        fishComponent = gameObject.GetComponent<FishComponent>();  
    }

    // Update is called once per frame
    public float speed = 10f;
    public float gunSpeed = 0.8f;

    float timeElapsed; // 前回弾を撃ってからの経過時間
    float timeout = 2.0f;
    void Update()
    {
        timeElapsed += Time.deltaTime;
        Vector3 r = new Vector3 (Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
        fishComponent.Move((target.transform.position - transform.position).normalized * speed * Time.deltaTime); // 索敵
    
        if(timeElapsed > timeout){ // 一定時間おきに弾を撃つ
            GameObject bullet_instance = Instantiate(bullet);
            bullet_instance.transform.parent = gameObject.transform;
            bullet_instance.transform.localPosition = new Vector3 (0,0,0);
            timeElapsed = 0.0f;
            BulletController bc = bullet_instance.GetComponent<BulletController>();
            bc.velocity = (target.transform.position - transform.position).normalized * gunSpeed; // 弾のスピード
        }
    }

    // 当たり判定
    void OnCollisionEnter(Collision collision)
    {

      //Debug.Log("Hit"); // ログを表示する
    }
}
