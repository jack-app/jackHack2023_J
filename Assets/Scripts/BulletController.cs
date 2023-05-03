using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// デフォルトでは右に飛ぶ
public class BulletController : MonoBehaviour
{
    public GameObject target;
    public Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        //velocity = new Vector3(-0.5f, 0f, 0f);
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity + (target.transform.position - transform.position)*0.01f);
    }

    void OnCollisionEnter2d(Collision2D col){
        Debug.Log("collision");
        /*if(gameObject.tag=="Enemy" && col.gameObject.tag == "Ally"){
            col.gameObject.GetComponent<FishComponent>().hp = 0;
        }
        Debug.Log(col.gameObject.tag);*/
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        // 物体が接触している間、常に呼ばれる
        Debug.Log("collision");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 物体が接触している間、常に呼ばれる
        if(gameObject.tag=="Enemy" && other.gameObject.tag == "Ally"){
            other.gameObject.GetComponent<FishComponent>().hp -= 1;
        }
        Debug.Log(gameObject.tag);

    }

}
