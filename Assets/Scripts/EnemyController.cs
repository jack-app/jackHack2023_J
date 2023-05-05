// 敵の動き

using S = System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("追跡するオブジェクト")]
    public GameObject target;
    [SerializeField]
    [Tooltip("撃つ弾")]
    public GameObject bullet;
    FishComponent fish;
    GameObject boundaryLine;
    private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
    // Start is called before the first frame update


    // Update is called once per frame
    public float speed = 10f;
    public float gunSpeed;

    float timeElapsed; // 前回弾を撃ってからの経過時間
    float timeout = 2.0f;

    bool isInsideCamera; // カメラ内にいるかどうか

    enum EnemyState {Searching, Approaching,};
    EnemyState enemyState = EnemyState.Searching;
    
    Vector3 fishDirection;
    void Start()
    {
        fish = gameObject.GetComponent<FishComponent>();  
        boundaryLine = GameObject.Find("BoundaryLine");

        // 魚が敵か味方かに応じて処理の向きを変えるためのもの
        if (gameObject.CompareTag("Ally")){
           fishDirection = Vector2.right; 
        }
        else if (gameObject.CompareTag("Enemy")){
           fishDirection = Vector2.left; 
        }else { Debug.Log(gameObject.name+"タグを設定してください"); }
    }

    void Update()
    {
        if(!isInsideCamera){ //Debug.Log("not inside of camera" + gameObject.name);
        return;} // もしカメラの範囲内にいないなら処理を終了

        switch(enemyState){
            case EnemyState.Searching:  //索敵
                Search();
                break;
            case EnemyState.Approaching:  // 敵に接近
                Approach();
                break;
        }
        if(fish.isDead()){
            var ct = _cancellationTokenSource.Token;
            transform.localScale = Vector3.zero;
            // 非同期メソッド実行
            _ = death(ct);
        }
    }


    float rotateDirection = 1;
    void Search(){ // 一定の方向に進みつつ回転しながら索敵
        // Ally, Enemy
        // Ray
        // Ally と Enemyで回転が逆?
        // カメラ内で索敵したい
        
        fish.Move(fishDirection * Time.deltaTime * speed);

        float rotationSpeed = 40;
        float angleZ = transform.eulerAngles.z;
        if(angleZ > 180){ angleZ -= 360; }
        if(angleZ > 30) {
            rotateDirection = -Time.deltaTime * rotationSpeed;
        } else if(-30 > angleZ){
            rotateDirection = Time.deltaTime * rotationSpeed;
        }
        transform.Rotate(0, 0, rotateDirection);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, fishDirection*100, 100, 0);

        /*
        if(hit.collider){
          Debug.Log(hit.collider.gameObject.name);
          if(hit.collider.gameObject.CompareTag("Ally")){
              target = hit.collider.gameObject;
              enemyState = EnemyState.Approaching;
          }
        }*/
        Shoot();
    }

    void Shoot(){
        timeElapsed += Time.deltaTime;
        if(timeElapsed > timeout){ // 一定時間おきに弾を撃つ
            GameObject bullet_instance = Instantiate(bullet);
            bullet_instance.tag = gameObject.tag;
            bullet_instance.transform.position = transform.position;
            bullet_instance.transform.rotation = transform.rotation;
            timeElapsed = 0.0f;
            BulletController bc = bullet_instance.GetComponent<BulletController>();
            bc.direction = fishDirection; // 弾の向き
            bc.speed = gunSpeed; // 弾の向き
        }
    }

    void Approach(){ // 敵を追跡
        Debug.Log("approach");
        if(target == null){ enemyState = EnemyState.Searching; return; } // 追跡対象が存在しなければ索敵モードに戻り処理を終了
        Vector3 r = new Vector3 (UnityEngine.Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
        fish.Move((target.transform.position - transform.position).normalized * speed * Time.deltaTime); // 敵を追跡
    
        Shoot();
    }


    // 非同期メソッド
    private async Task death(CancellationToken token)
    {

        await Task.Delay(S.TimeSpan.FromSeconds(1), token);

        // 死ぬ
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        _cancellationTokenSource.Cancel();
        _cancellationTokenSource.Dispose();
    }

    //　カメラから外れた
    private void OnBecameInvisible() {
        isInsideCamera = false;
    }
    //　カメラ内に入った
    private void OnBecameVisible() {
        isInsideCamera = true;
    }
    // 当たり判定
    void OnCollisionEnter(Collision collision)
    {

      //Debug.Log("Hit"); // ログを表示する
    }
}
