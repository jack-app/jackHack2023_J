using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamController : MonoBehaviour
{
    public GameObject objectToStretch; // 延ばすオブジェクトのGameObject
    public GameObject Platerobject; // プレイヤーのGameObject
    public float scaleSpeed = 0.5f; // オブジェクトの伸縮速度
    private Vector3 initialScale; // オブジェクトの初期サイズ
    private Vector3 initialPosition; // オブジェクトの初期位置
    private Vector3 PlayerPosition; // プレイヤーの初期位置
    private bool isExtending = false;  // 延びているかどうかを示すフラグ

    public GameObject RomantikBeam;  // 生成するオブジェクトのプレハブ
    public float moveSpeed = 1f;  // 動く速度

    private bool isGenerating = false;  // 生成中かどうかを示すフラグ
    private GameObject generatedObject;  // 生成されたオブジェクトの参照

    // Start is called before the first frame update
    void Start()
    {
        initialScale = objectToStretch.transform.localScale; // 四角形の初期サイズを取得
        initialPosition = objectToStretch.transform.position; // 四角形の初期位置を取得
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPosition = Platerobject.transform.position;
        // スペースキーが押されたら、延びるフラグをtrueにする
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isExtending = true;
        }

        // スペースキーが離されたら、延びるフラグをfalseにする
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isExtending = false;
        }

        if (isExtending) // スペースキーが押されている間
        {
            if(objectToStretch.transform.localScale.x < 150){
                Vector3 newScale = new Vector3(objectToStretch.transform.localScale.x + scaleSpeed, objectToStretch.transform.localScale.y, objectToStretch.transform.localScale.z); // オブジェクトの幅を拡大
                objectToStretch.transform.localScale = newScale; // オブジェクトのサイズを更新
            }
            Vector3 newPosition = PlayerPosition + new Vector3(objectToStretch.transform.localScale.x/2, 0, 0); // オブジェクトの新しい位置
            objectToStretch.transform.position = newPosition; // オブジェクトを移動
        }
        else // スペースキーが押されていない間
        {
            objectToStretch.transform.localScale = initialScale; // オブジェクトのサイズを初期サイズに戻す
            objectToStretch.transform.position = PlayerPosition;// オブジェクトのサイズを初期位置に戻す
        }


        if (Input.GetKeyDown(KeyCode.B) && !isGenerating)
        {
            generatedObject = Instantiate(RomantikBeam, transform.position, Quaternion.identity);
            isGenerating = true;
        }

        if (generatedObject != null)
        {
            Vector3 position = generatedObject.transform.position;
            position.x += moveSpeed * Time.deltaTime;
            generatedObject.transform.position = position;
            if(position.x > 8)
            {
                Destroy(generatedObject);
            }
        }
        else{
            isGenerating = false;
        }
    }
    
}
