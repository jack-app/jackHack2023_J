// 敵の動き
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject target;
    public GameObject bullet;
    FishComponent fishComponent;
    
    // Start is called before the first frame update
    void Start()
    {
        fishComponent = gameObject.GetComponent<FishComponent>();  
    }

    // Update is called once per frame
    public float speed;

    float timeElapsed;
    float timeout = 2.0f;
    Vector3 vel;
    void Update()
    {
        timeElapsed += Time.deltaTime;
        
        fishComponent.Move(vel * Time.deltaTime * Random.Range(-0.1f, 1f)); // 索敵

    
        if(timeElapsed > timeout){
            GameObject bullet_instance = Instantiate(bullet);
            bullet_instance.transform.parent = gameObject.transform;
            bullet_instance.transform.localPosition = new Vector3 (0,0,0);
            timeElapsed = 0.0f;
            BulletController bc= bullet_instance.GetComponent<BulletController>();
            bc.velocity = (target.transform.position - transform.position).normalized * speed;
        }
    }

    // 当たり判定
    void OnCollisionEnter(Collision collision)
    {

      //Debug.Log("Hit"); // ログを表示する
    }
}
