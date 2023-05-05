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
        transform.Translate(vec);
    }

    public bool isDead(){ // 死亡しているかを表す
        return hp <= 0;
    }
    // Update is called once per frame
    void Update()
    {
        float boundary_x = boundaryLine.transform.position.x;
        if(gameObject.CompareTag("Ally")){
            if(transform.position.x > boundary_x){
                transform.position = new Vector3 (boundary_x, transform.position.y, transform.position.z);
            }
        } else if(gameObject.CompareTag("Enemy")){
            if(transform.position.x < boundary_x){
                transform.position = new Vector3 (boundary_x, transform.position.y, transform.position.z);
            }
        }
    }
}