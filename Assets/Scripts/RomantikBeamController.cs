using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RomantikBeamController : MonoBehaviour
{
    public GameObject target; // プレイヤーのGameObject
    public float moveSpeed = 100f;  // 動く速度
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
        if(position.x > 400)
        {
            Destroy(gameObject);
        }
    }
}
