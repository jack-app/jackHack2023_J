using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class PlayerController : MonoBehaviour
{

    //===== ï¿½ï¿½`ï¿½Ìˆï¿½ =====
    private Animator anim;  //Animatorï¿½ï¿½animï¿½Æ‚ï¿½ï¿½ï¿½ï¿½Ïï¿½ï¿½Å’ï¿½`ï¿½ï¿½ï¿½ï¿½


    //private float speed
    public float speed;

    [SerializeField]
    [Tooltip("Å¬Šp“x(-180`180")]
    private float MinAngle;

    [SerializeField]
    [Tooltip("Å‘åŠp“x(-180`180")]
    private float MaxAngle;

    [SerializeField]
    [Tooltip("‰ñ“]‚·‚éƒXƒs[ƒh")]
    private float rotationSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        //speed = 5f;

        //ï¿½Ïï¿½animï¿½ÉAAnimatorï¿½Rï¿½ï¿½ï¿½|ï¿½[ï¿½lï¿½ï¿½ï¿½gï¿½ï¿½İ’è‚·ï¿½ï¿½
        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //ï¿½Ú“ï¿½
        float position_x = Mathf.Min(transform.position.x  + Input.GetAxis("Horizontal") * Time.deltaTime * speed, -8f);
        float position_y = transform.position.y + Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.position = new Vector3(position_x, position_y, 0f);

        //ï¿½ï¿½ï¿½ï¿½ï¿½Aï¿½ã‚ªï¿½ï¿½ï¿½ï¿½ï¿½ê‚½ï¿½ï¿½È‚ï¿½
        if (Input.GetKey("up"))
        {
            //Boolï¿½^ï¿½Ìƒpï¿½ï¿½ï¿½ï¿½ï¿½[ï¿½^ï¿½[ï¿½Å‚ï¿½ï¿½ï¿½Boolswimï¿½ï¿½Trueï¿½É‚ï¿½ï¿½ï¿½
            anim.SetBool("Boolswim", true);
        }

        //ï¿½ï¿½ï¿½ï¿½ï¿½Aï¿½ã‚ªï¿½ï¿½ï¿½ê‚½ï¿½È‚ï¿½È‚ï¿½
        if (Input.GetKeyUp("up"))
        {
            //Boolï¿½^ï¿½Ìƒpï¿½ï¿½ï¿½ï¿½ï¿½[ï¿½^ï¿½[ï¿½Å‚ï¿½ï¿½ï¿½Boolswimï¿½ï¿½Falseï¿½É‚ï¿½ï¿½ï¿½
            anim.SetBool("Boolswim", false);
        }

        //ï¿½ï¿½ï¿½ï¿½ï¿½Aï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ê‚½ï¿½ï¿½È‚ï¿½
        if (Input.GetKey("down"))
        {
            //Boolï¿½^ï¿½Ìƒpï¿½ï¿½ï¿½ï¿½ï¿½[ï¿½^ï¿½[ï¿½Å‚ï¿½ï¿½ï¿½Boolswimï¿½ï¿½Trueï¿½É‚ï¿½ï¿½ï¿½
            anim.SetBool("Boolswim", true);
        }

        //ï¿½ï¿½ï¿½ï¿½ï¿½Aï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ê‚½ï¿½È‚ï¿½È‚ï¿½
        if (Input.GetKeyUp("down"))
        {
            //Boolï¿½^ï¿½Ìƒpï¿½ï¿½ï¿½ï¿½ï¿½[ï¿½^ï¿½[ï¿½Å‚ï¿½ï¿½ï¿½Boolswimï¿½ï¿½Falseï¿½É‚ï¿½ï¿½ï¿½
            anim.SetBool("Boolswim", false);
        }

        //ï¿½ï¿½ï¿½ï¿½ï¿½Aï¿½Eï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ê‚½ï¿½ï¿½È‚ï¿½
        if (Input.GetKey("right"))
        {
            //Boolï¿½^ï¿½Ìƒpï¿½ï¿½ï¿½ï¿½ï¿½[ï¿½^ï¿½[ï¿½Å‚ï¿½ï¿½ï¿½Boolswimï¿½ï¿½Trueï¿½É‚ï¿½ï¿½ï¿½
            anim.SetBool("Boolswim", true);
        }

        //ï¿½ï¿½ï¿½ï¿½ï¿½Aï¿½Eï¿½ï¿½ï¿½ï¿½ï¿½ê‚½ï¿½È‚ï¿½È‚ï¿½
        if (Input.GetKeyUp("right"))
        {
            //Boolï¿½^ï¿½Ìƒpï¿½ï¿½ï¿½ï¿½ï¿½[ï¿½^ï¿½[ï¿½Å‚ï¿½ï¿½ï¿½Boolswimï¿½ï¿½Falseï¿½É‚ï¿½ï¿½ï¿½
            anim.SetBool("Boolswim", false);
        }

        //ï¿½ï¿½ï¿½ï¿½ï¿½Aï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ê‚½ï¿½ï¿½È‚ï¿½
        if (Input.GetKey("left"))
        {
            //Boolï¿½^ï¿½Ìƒpï¿½ï¿½ï¿½ï¿½ï¿½[ï¿½^ï¿½[ï¿½Å‚ï¿½ï¿½ï¿½Boolswimï¿½ï¿½Trueï¿½É‚ï¿½ï¿½ï¿½
            anim.SetBool("Boolswim", true);
        }

        //ï¿½ï¿½ï¿½ï¿½ï¿½Aï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ê‚½ï¿½È‚ï¿½È‚ï¿½
        if (Input.GetKeyUp("left"))
        {
            //Boolï¿½^ï¿½Ìƒpï¿½ï¿½ï¿½ï¿½ï¿½[ï¿½^ï¿½[ï¿½Å‚ï¿½ï¿½ï¿½Boolswimï¿½ï¿½Falseï¿½É‚ï¿½ï¿½ï¿½
            anim.SetBool("Boolswim", false);
        }

        // ã‰ºƒL[‚Ì“ü—Í‚ğæ“¾
        float vertical = Input.GetAxis("Vertical");
        // Œ»İ‚ÌGameObject‚ÌX²•ûŒü‚ÌŠp“x‚ğæ“¾
        float currentXAngle = transform.eulerAngles.x;
        // Œ»İ‚ÌŠp“x‚ª180‚æ‚è‘å‚«‚¢ê‡
        if (currentXAngle > 180)
        {
            // ƒfƒtƒHƒ‹ƒg‚Å‚ÍŠp“x‚Í0`360‚È‚Ì‚Å-180`180‚Æ‚È‚é‚æ‚¤‚É•â³
            currentXAngle = currentXAngle - 360;
        }
        // (Œ»İ‚ÌŠp“x‚ªÅ¬Šp“xˆÈã‚©‚ÂƒL[“ü—Í‚ª0–¢–(‰ºƒL[‰Ÿ‰º)) ‚Ü‚½‚Í (Œ»İ‚ÌŠp“x‚ªÅ‘åŠp“xˆÈ‰º‚©‚ÂƒL[“ü—Í‚ª0‚æ‚è‘å‚«‚¢(ãƒL[‰Ÿ‰º))‚Ì
        if ((currentXAngle >= MinAngle && vertical > 0) || (currentXAngle <= MaxAngle && vertical < 0))
        {
            // X²‚ğŠî€‚É‰ñ“]‚³‚¹‚é
            transform.Rotate(new Vector3(-vertical * rotationSpeed, 0, 0));
        }

    }
}
