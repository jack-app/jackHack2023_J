using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    //===== ��`�̈� =====
    private Animator anim;  //Animator��anim�Ƃ����ϐ��Œ�`����



    public Slider hpBar;

    //private float speed
    public float speed;

    [SerializeField]
    [Tooltip("�ŏ��p�x(-180�`180")]
    private float MinAngle;

    [SerializeField]
    [Tooltip("�ő�p�x(-180�`180")]
    private float MaxAngle;

    [SerializeField]
    [Tooltip("��]����X�s�[�h")]
    private float rotationSpeed = 1;

    // Start is called before the first frame update
    FishComponent fish;
    void Start()
    {
        //speed = 5f;
        fish = GetComponent<FishComponent>();

        if(hpBar != null)
        {
            hpBar.value = 1;
        }

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

        if(hpBar != null)
        {
            hpBar.value = ((float)fish.hp) / ((float)fish.max_hp);
        }

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

        // �㉺�L�[�̓��͂��擾
        float vertical = Input.GetAxis("Vertical");
        // ���݂�GameObject��X�������̊p�x���擾
        float currentXAngle = transform.eulerAngles.x;
        // ���݂̊p�x��180���傫���ꍇ
        if (currentXAngle > 180)
        {
            // �f�t�H���g�ł͊p�x��0�`360�Ȃ̂�-180�`180�ƂȂ�悤�ɕ␳
            currentXAngle = currentXAngle - 360;
        }
        // (���݂̊p�x���ŏ��p�x�ȏォ�L�[���͂�0����(���L�[����)) �܂��� (���݂̊p�x���ő�p�x�ȉ����L�[���͂�0���傫��(��L�[����))�̎�
        if ((currentXAngle >= MinAngle && vertical > 0) || (currentXAngle <= MaxAngle && vertical < 0))
        {
            // X������ɉ�]������
            transform.Rotate(new Vector3(-vertical * rotationSpeed, 0, 0));
        }

    }
}
