using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RomantikBeamController : MonoBehaviour
{
    public GameObject target; // プレイヤーのGameObject
    public float moveSpeed = 100f;  // 動く速度
    public int romantikDamage = 30;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        gameObject.transform.position = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = gameObject.transform.position;
        position.x += moveSpeed * Time.deltaTime;
        gameObject.transform.position = position;
    }
    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other == null){return;}
        if(other.gameObject.tag == "Enemy"){
            if(other.gameObject.GetComponent<FishComponent>() == null) return;
            other.gameObject.GetComponent<FishComponent>().hp -= romantikDamage;
            //Debug.Log(other.gameObject.GetComponent<FishComponent>().hp);
            //Debug.Log("hit");
        }
    }
}
