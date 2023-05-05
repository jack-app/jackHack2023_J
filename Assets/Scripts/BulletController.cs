using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// デフォルトでは右に飛ぶ
public class BulletController : MonoBehaviour
{

    [SerializeField]
    [Tooltip("弾の速度")]
    public float speed;
    public Vector3 direction;
    public int power;
    // Start is called before the first frame update
    void Start()
    {
        //velocity = new Vector3(-0.5f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        // 一定速度で動く
        transform.Translate(direction * speed);
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
        if(gameObject.tag=="Enemy" && other.gameObject.tag == "Ally"  //敵の弾が味方に当たる、または味方の弾が敵に当たる
            || gameObject.tag=="Ally" && other.gameObject.tag == "Enemy"){
            if(other.gameObject.GetComponent<FishComponent>() == null) return; // 魚以外なら無視
            other.gameObject.GetComponent<FishComponent>().hp -= power; // 魚ならHPを1減らす
        }
    }
    //　カメラから外れた
    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}