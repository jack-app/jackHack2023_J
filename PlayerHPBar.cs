using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    //最大HPと現在HP
    int maxHP = 100;
    int currentHP;

    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        //Sliderを満タンにする
        slider.value = 1;
        //現在HPの初期化
        currentHP = maxHP;
        Debug.Log("Start currentHP :"+ currentHP);
    }

    public void OnTriggerEnter(Collider collider)
    {
        //Enemyタグのオブジェクトと接触時発動
        if (collider.gameObject.tag == "Player")
        {
            //ダメージの設定
            int damage = 5;
            Debug.Log("damage :" + damage);
            //現在HPを減らす
            currentHP = currentHP - damage;
            Debug.Log("After currentHP :" + currentHP);
            //最大HPにおける現在HPをSliderに反映
            slider.value = (float)currentHP / (float)maxHP;;
            Debug.Log("slider.value :" + slider.value);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
