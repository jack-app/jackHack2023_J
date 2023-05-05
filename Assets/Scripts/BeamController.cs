using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeamController : MonoBehaviour
{
    public GameObject NomalBeam; // 延ばすオブジェクトのGameObject
    public GameObject Platerobject; // プレイヤーのGameObject
    public float scaleSpeed = 0.5f; // オブジェクトの伸縮速度
    private Vector3 initialScale; // オブジェクトの初期サイズ
    private Vector3 initialPosition; // オブジェクトの初期位置
    private Vector3 PlayerPosition; // プレイヤーの初期位置
    private bool isExtending = false;  // 延びているかどうかを示すフラグ
    private GameObject generatedNomal;

    public GameObject RomantikBeam;  // 生成するオブジェクトのプレハブ
    
    private GameObject generatedRomaitik;  // 生成されたオブジェクトの参照

    public int romantikGage = 0;
    public Slider romantikBar;
    public int romantikGageMax = 3;

    // Start is called before the first frame update
    void Start()
    {
        initialScale = NomalBeam.transform.localScale; // 四角形の初期サイズを取得
        initialPosition = NomalBeam.transform.position; // 四角形の初期位置を取得
        Platerobject = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPosition = Platerobject.transform.position;
        // スペースキーが押されたら、延びるフラグをtrueにする
        if (Input.GetKeyDown(KeyCode.Space))
        {
            generatedNomal = Instantiate(NomalBeam, transform.position, Quaternion.identity,Platerobject.transform);
            isExtending = true;
        }

        // スペースキーが離されたら、延びるフラグをfalseにする
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Destroy(generatedNomal);
            isExtending = false;
        }

        if (isExtending) // スペースキーが押されている間
        {
            if(generatedNomal.transform.localScale.x < 150){
                
                Vector3 newScale = new Vector3(generatedNomal.transform.localScale.x + scaleSpeed, generatedNomal.transform.localScale.y, generatedNomal.transform.localScale.z); // オブジェクトの幅を拡大
                generatedNomal.transform.localScale = newScale; // オブジェクトのサイズを更新
            }
            Vector3 newPosition = PlayerPosition + new Vector3(generatedNomal.transform.localScale.x/2, 0, 0); // オブジェクトの新しい位置
            generatedNomal.transform.position = newPosition; // オブジェクトを移動
        }
        else // スペースキーが押されていない間
        {
            
        }


        if (Input.GetKeyDown(KeyCode.B) && romantikGage>=3)
        {
            generatedRomaitik = Instantiate(RomantikBeam, transform.position, Quaternion.identity,Platerobject.transform);
            romantikGage = 0;
        }

        romantikBar.value = (((float)romantikGage) / ((float)romantikGageMax));
    }
    
}
