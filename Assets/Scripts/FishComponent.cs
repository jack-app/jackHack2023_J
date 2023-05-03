using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishComponent : MonoBehaviour
{
    // Start is called before the first frame update

    public int hp;
    public int max_hp;
    void Start()
    {
        hp = max_hp;
    }

    public void Move(Vector3 vec)
    {
        float position_x = Mathf.Max(transform.position.x + vec.x, 0);
        float position_y = transform.position.y+ vec.y;
        transform.position = new Vector3(position_x, position_y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0){
            gameObject.SetActive(false);
        }
    }

}
