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
    public GameObject boundaryLine;
    private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
    // Start is called before the first frame update
    void Start()
    {
        fish = gameObject.GetComponent<FishComponent>();  
        boundaryLine = GameObject.Find("BoundaryLine");
    }

    // Update is called once per frame
    public float speed = 10f;
    public float gunSpeed = 0.8f;

    float timeElapsed; // 前回弾を撃ってからの経過時間
    float timeout = 2.0f;

    bool isInsideCamera; // カメラ内にいるかどうか



    enum EnemyState {Searching, Approaching,};
    EnemyState enemyState = EnemyState.Searching;
    void Update()
    {
        if(!isInsideCamera){return;} // もしカメラの範囲内にいないなら処理を終了

        switch(enemyState){
            case EnemyState.Searching:  //索敵
                Search();
                break;
            case EnemyState.Approaching:  // 敵に接近
                Approach();
                break;
        }
    }


    void Search(){ // 一定の方向に進みつつ回転しながら索敵
        // Ally, Enemy
        // Ray
        // Ally と Enemyで回転が逆?
        // カメラ内で索敵したい
        RaycastHit hit;
        fish.Move(Vector3.forward * Time.deltaTime * speed);
        if(transform.eulerAngles.z > 30f){
            transform.Rotate(0, 0, -1);
        } else{
            transform.Rotate(0, 0, 1);
        }
        Debug.DrawRay(gameObject.transform.position, new Vector3(1, 0, 0), Color.red, 6f);
        if(Physics.Raycast(gameObject.transform.position, new Vector3(1, 0, 0),out hit, 6.0f)){
           target = hit.collider.gameObject;
           Debug.Log("aaaa");
        }
    }

    void Approach(){ // 敵を追跡
        if(target == null){ enemyState = EnemyState.Searching; return; } // 追跡対象が存在しなければ索敵モードに戻り処理を終了
        timeElapsed += Time.deltaTime;
        Vector3 r = new Vector3 (UnityEngine.Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
        fish.Move((target.transform.position - transform.position).normalized * speed * Time.deltaTime); // 索敵
    
        if(timeElapsed > timeout){ // 一定時間おきに弾を撃つ
            GameObject bullet_instance = Instantiate(bullet);
            bullet_instance.transform.parent = gameObject.transform;
            bullet_instance.transform.localPosition = new Vector3 (0,0,0);
            timeElapsed = 0.0f;
            BulletController bc = bullet_instance.GetComponent<BulletController>();
            bc.velocity = (target.transform.position - transform.position).normalized * gunSpeed; // 弾のスピード
        }
        if(fish.isDead()){
            var ct = _cancellationTokenSource.Token;
            transform.localScale = Vector3.zero;
            // 非同期メソッド実行
            _ = death(ct);
        }
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
