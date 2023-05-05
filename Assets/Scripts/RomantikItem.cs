using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RomantikItem : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other == null){return;}
        if(other.gameObject.tag == "Ally"){
            Player.GetComponent<BeamController>().romantikGage += 1;
            Destroy(gameObject);
        }
    }
}
