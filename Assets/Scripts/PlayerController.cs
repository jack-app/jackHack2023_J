using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //===== ��`�̈� =====
    private Animator anim;  //Animator��anim�Ƃ����ϐ��Œ�`����


    //private float speed
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //speed = 5f;

        //�ϐ�anim�ɁAAnimator�R���|�[�l���g��ݒ肷��
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //�ړ�
        float position_x = Mathf.Min(transform.position.x  + Input.GetAxis("Horizontal") * Time.deltaTime * speed, -8f);
        float position_y = transform.position.y + Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.position = new Vector3(position_x, position_y, 0f);

        //�����A�オ�����ꂽ��Ȃ�
        if (Input.GetKey("up"))
        {
            //Bool�^�̃p�����[�^�[�ł���Boolswim��True�ɂ���
            anim.SetBool("Boolswim", true);
        }

        //�����A�オ���ꂽ�Ȃ�Ȃ�
        if (Input.GetKeyUp("up"))
        {
            //Bool�^�̃p�����[�^�[�ł���Boolswim��False�ɂ���
            anim.SetBool("Boolswim", false);
        }

        //�����A���������ꂽ��Ȃ�
        if (Input.GetKey("down"))
        {
            //Bool�^�̃p�����[�^�[�ł���Boolswim��True�ɂ���
            anim.SetBool("Boolswim", true);
        }

        //�����A�������ꂽ�Ȃ�Ȃ�
        if (Input.GetKeyUp("down"))
        {
            //Bool�^�̃p�����[�^�[�ł���Boolswim��False�ɂ���
            anim.SetBool("Boolswim", false);
        }

        //�����A�E�������ꂽ��Ȃ�
        if (Input.GetKey("right"))
        {
            //Bool�^�̃p�����[�^�[�ł���Boolswim��True�ɂ���
            anim.SetBool("Boolswim", true);
        }

        //�����A�E�����ꂽ�Ȃ�Ȃ�
        if (Input.GetKeyUp("right"))
        {
            //Bool�^�̃p�����[�^�[�ł���Boolswim��False�ɂ���
            anim.SetBool("Boolswim", false);
        }

        //�����A���������ꂽ��Ȃ�
        if (Input.GetKey("left"))
        {
            //Bool�^�̃p�����[�^�[�ł���Boolswim��True�ɂ���
            anim.SetBool("Boolswim", true);
        }

        //�����A�������ꂽ�Ȃ�Ȃ�
        if (Input.GetKeyUp("left"))
        {
            //Bool�^�̃p�����[�^�[�ł���Boolswim��False�ɂ���
            anim.SetBool("Boolswim", false);
        }

    }
}
