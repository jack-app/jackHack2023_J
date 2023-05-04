using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    FishComponent fish;
    // Start is called before the first frame update
    void Start()
    {
        fish = GetComponent<FishComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        // ボスが死んだ場合はステージ遷移する        
        if(fish.isDead()){
            SceneManager.LoadScene("StageClear");
        }
    }
}
