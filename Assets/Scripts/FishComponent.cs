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
    GameObject boundaryLine;
    void Start()
    {
        hp = max_hp; // 最初のHPは最大値
        boundaryLine = GameObject.Find("BoundaryLine");
    }

    public void Move(Vector3 vec)
    {
        float boundary_x = boundaryLine.transform.position.x;
        float position_x = transform.position.x + vec.x;
        float position_y = transform.position.y + vec.y;
        if (gameObject.tag == "Ally"){
            position_x = Mathf.Min(position_x + vec.x, boundary_x); // x座標がboundaryより右には行かない
        } else if (gameObject.tag == "Enemy"){
            position_x = Mathf.Max(position_x + vec.x, boundary_x); // x座標がboundaryより左には行かない
        } else {
            Debug.Log("想定外");
        }
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