using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// デフォルトでは右に飛ぶ
public class BulletController : MonoBehaviour
{
    public GameObject target;
    Vector3 startPosition;

    [SerializeField]
    [Tooltip("弾の速度")]
    public Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        //velocity = new Vector3(-0.5f, 0f, 0f);
        target = GameObject.Find("Player");
        startPosition = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 一定速度で動きつつ ターゲットに追従する
        transform.Translate(velocity + (startPosition - transform.position)*0.01f);
    }

    void OnCollisionEnter2d(Collision2D col){
        /*if(gameObject.tag=="Enemy" && col.gameObject.tag == "Ally"){
            col.gameObject.GetComponent<FishComponent>().hp = 0;
        }
        Debug.Log(col.gameObject.tag);*/
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        // 物体が接触している間、常に呼ばれる
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(gameObject.tag=="Enemy" && other.gameObject.tag == "Ally"){
            if(other.gameObject.GetComponent<FishComponent>() == null) return;
            other.gameObject.GetComponent<FishComponent>().hp -= 1;
            Destroy(gameObject);
        }
    }
    //　カメラから外れた
    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}