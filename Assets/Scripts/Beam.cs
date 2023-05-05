using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public BeamController romantik;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other == null){return;}
        if(other.gameObject.tag == "Enemy"){
            if(other.gameObject.GetComponent<FishComponent>() == null) return;
            other.gameObject.GetComponent<FishComponent>().hp -= 15;
            //Debug.Log(other.gameObject.GetComponent<FishComponent>().hp);
            //Debug.Log("hit");
        }
    }
    private void OnTriggerStay2D(Collider2D other)
       {
           
       }
}
