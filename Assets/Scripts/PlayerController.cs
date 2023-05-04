using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{

    //===== 定義領域 =====
    private Animator anim;  //Animatorをanimという変数で定義する�

    public Slider hpBar;

    //private float speed
    public float speed;

    [SerializeField]
    [Tooltip("最小角度(-180～180")]
    private float MinAngle;

    [SerializeField]
    [Tooltip("最大角度(-180～180")]
    private float MaxAngle;

    [SerializeField]
    [Tooltip("回転するスピード")]
    private float rotationSpeed = 1;

    // Start is called before the first frame update
    FishComponent fish;
    void Start()
    {
        //speed = 5f;


        // FishComponentコンポーネントを設定
        fish = GetComponent<FishComponent>();

        if(hpBar != null)
        {
            hpBar.value = 1;
        }

        //変数animに、Animatorコンポーネントを設定する
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーのx軸が-8fよりは右に行かないようにする
        //float position_x = transform.position.x  + Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        //float position_y = transform.position.y + Input.GetAxis("Vertical") * Time.deltaTime * speed;

        //transform.position = new Vector3(position_x, position_y, 0f);
        fish.Move(new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * speed,
                    Input.GetAxis("Vertical") * Time.deltaTime * speed));

        // hp バーの長さをhpの値に
        if(hpBar != null)
        {
            hpBar.value = ((float)fish.hp) / ((float)fish.max_hp);
        }
        
        // もしプレイヤーが死んでいるならゲームオーバー
        if(fish.isDead()){
            SceneManager.LoadScene("GameOver");
        }

        // 現在のGameObjectのX軸方向の角度を取得
        if (Input.GetKey("up"))
        {
            //Bool型のパラメーターであるBoolswimをTrueにする
            anim.SetBool("Boolswim", true);
        }

        //もし、上が離れたならなら
        if (Input.GetKeyUp("up"))
        {
            //Bool型のパラメーターであるBoolswimをFalseにする
            anim.SetBool("Boolswim", false);
        }

        //もし、下が押されたらなら
        if (Input.GetKey("down"))
        {
            //Bool型のパラメーターであるBoolswimをTrueにする
            anim.SetBool("Boolswim", true);
        }

        //もし、下が離れたならなら
        if (Input.GetKeyUp("down"))
        {
            //Bool型のパラメーターであるBoolswimをFalseにする
            anim.SetBool("Boolswim", false);
        }

        //もし、右が押されたらなら
        if (Input.GetKey("right"))
        {
            //Bool型のパラメーターであるBoolswimをTrueにする
            anim.SetBool("Boolswim", true);
        }

        //もし、右が離れたならなら
        if (Input.GetKeyUp("right"))
        {
            //Bool型のパラメーターであるBoolswimをFalseにする
            anim.SetBool("Boolswim", false);
        }

        //もし、左が押されたらなら
        if (Input.GetKey("left"))
        {
            //Bool型のパラメーターであるBoolswimをTrueにする
            anim.SetBool("Boolswim", true);
        }

        //もし、左が離れたならなら
        if (Input.GetKeyUp("left"))
        {
            //Bool型のパラメーターであるBoolswimをFalseにする
            anim.SetBool("Boolswim", false);
        }

        // 上下キーの入力を取得
        float vertical = Input.GetAxis("Vertical");
         // 現在のGameObjectのX軸方向の角度を取得
        float currentXAngle = transform.eulerAngles.x;
        // 現在の角度が180より大きい場合
        if (currentXAngle > 180)
        {
            // デフォルトでは角度は0～360なので-180～180となるように補正
            currentXAngle = currentXAngle - 360;
        }
        // (現在の角度が最小角度以上かつキー入力が0未満(下キー押下)) または (現在の角度が最大角度以下かつキー入力が0より大きい(上キー押下))の時
        if ((currentXAngle >= MinAngle && vertical > 0) || (currentXAngle <= MaxAngle && vertical < 0))
        {
            // X軸を基準に回転させる
            transform.Rotate(new Vector3(-vertical * rotationSpeed, 0, 0));
        }

    }

    //　カメラから外れた
    private void OnBecameInvisible() {
        SceneManager.LoadScene("GameOver");
    }
}
