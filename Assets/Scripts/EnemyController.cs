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
    FishComponent fishComponent;
    public GameObject boundaryLine;
    private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
    // Start is called before the first frame update
    void Start()
    {
        fishComponent = gameObject.GetComponent<FishComponent>();  
    }

    // Update is called once per frame
    public float speed = 10f;
    public float gunSpeed = 0.8f;

    float timeElapsed; // 前回弾を撃ってからの経過時間
    float timeout = 2.0f;

    bool isInsideCamera; // カメラ内にいるかどうか
    void Update()
    {

        if(!isInsideCamera){return;} // もしカメラの範囲内にいないなら処理を終了

        timeElapsed += Time.deltaTime;
        Vector3 r = new Vector3 (UnityEngine.Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
        fishComponent.Move((target.transform.position - transform.position).normalized * speed * Time.deltaTime); // 索敵
    
        if(timeElapsed > timeout){ // 一定時間おきに弾を撃つ
            GameObject bullet_instance = Instantiate(bullet);
            bullet_instance.transform.parent = gameObject.transform;
            bullet_instance.transform.localPosition = new Vector3 (0,0,0);
            timeElapsed = 0.0f;
            BulletController bc = bullet_instance.GetComponent<BulletController>();
            bc.velocity = (target.transform.position - transform.position).normalized * gunSpeed; // 弾のスピード
        }
        if(fishComponent.isDead()){
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
