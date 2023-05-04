using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishComponent : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    [Tooltip("HP")]
    public int hp;

    [SerializeField]
    [Tooltip("最大HP")]
    public int max_hp;
    void Start()
    {
        hp = max_hp; // 最初のHPは最大値
    }

    public void Move(Vector3 vec)
    {
        float position_x = Mathf.Max(transform.position.x + vec.x, 0); // x座標が0より左には行かない
        float position_y = transform.position.y + vec.y;
        transform.position = new Vector3(position_x, position_y, transform.position.z);
    }

    public bool isDead(){ // 死亡しているかを表す
        return hp <= 0;
    }
    // Update is called once per frame
    void Update()
    {
    }
}