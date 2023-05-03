using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //===== 定義領域 =====
    private Animator anim;  //Animatorをanimという変数で定義する


    //private float speed
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //speed = 5f;

        //変数animに、Animatorコンポーネントを設定する
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //移動
        transform.position += new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f, 0f);
        transform.position += new Vector3(0f, Input.GetAxis("Vertical") * Time.deltaTime * speed, 0f);

        //もし、上が押されたらなら
        if (Input.GetKey("up"))
        {
            //Bool型のパラメーターであるBoolswimをTrueにする
            anim.SetBool("Boolswim", true);

            transform.rotate += new Vector3(0, 0, 3);
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

    }
}
