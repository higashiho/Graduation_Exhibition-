using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColBullet : MonoBehaviour
{
    [SerializeField]
    private BaseBullet bullet;
    // 当たり判定
    private void OnCollisionEnter2D(Collision2D col) 
    {
        if(col.gameObject.tag == "Wall" || col.gameObject.tag == "Trump")
        {
            // 非同期をキャンセルしてプールに格納
            bullet.cts.Cancel();
            
            bullet.objectPoolCallBack?.Invoke(bullet);
        }

        if(col.gameObject.tag == "Player")
        {

            // 非同期をキャンセルしてプールに格納
            bullet.cts.Cancel();
            bullet.objectPoolCallBack?.Invoke(bullet);

        }
    }
}
