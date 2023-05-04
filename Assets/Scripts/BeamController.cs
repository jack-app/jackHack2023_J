using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamController : MonoBehaviour
{
    public GameObject objectToStretch; // 延ばすオブジェクトのGameObject
    public float scaleSpeed = 0.5f; // オブジェクトの伸縮速度
    private Vector3 initialScale; // オブジェクトの初期サイズ
    private Vector3 initialPosition; // オブジェクトの初期位置
    // Start is called before the first frame update
    void Start()
    {
        initialScale = objectToStretch.transform.localScale; // 四角形の初期サイズを取得
        initialPosition = objectToStretch.transform.position; // 四角形の初期位置を取得
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) // スペースキーが押されている間
        {
            if(objectToStretch.transform.localScale.x < 24){
                Vector3 newScale = new Vector3(objectToStretch.transform.localScale.x + scaleSpeed, objectToStretch.transform.localScale.y, objectToStretch.transform.localScale.z); // オブジェクトの幅を拡大
                objectToStretch.transform.localScale = newScale; // オブジェクトのサイズを更新
                float moveDistance = scaleSpeed/2; // オブジェクトを移動する距離
                Vector3 newPosition = objectToStretch.transform.position + new Vector3(moveDistance, 0, 0); // オブジェクトの新しい位置
                objectToStretch.transform.position = newPosition; // オブジェクトを移動
            }
        }
        else // スペースキーが押されていない間
        {
            objectToStretch.transform.localScale = initialScale; // オブジェクトのサイズを初期サイズに戻す
            objectToStretch.transform.localPosition = new Vector3(0,0,0);// オブジェクトのサイズを初期位置に戻す
        }
    }
}
