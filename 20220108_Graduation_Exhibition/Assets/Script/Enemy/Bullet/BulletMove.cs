using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks; 
using System.Threading;


public class BulletMove
{
    public static BulletMove MoveBullet{get;private set;} = new BulletMove();

    public void Move(BaseBullet tmpBullet)
    {
        // 弾に速度を与える
        tmpBullet.GetComponent<Rigidbody2D>().velocity = tmpBullet.ShotForward * tmpBullet.BulletsData.TrumpSpeed;
        Debug.Log("弾生成");
    }

    // 指定秒後にキャンセルが要求されていなければプールに格納
    public async UniTask Callback(BaseBullet tmpObj, BulletData bulletData, CancellationToken token)
    {
        await UniTask.Delay(bulletData.DeleteTime * Const.CHANGE_SECOND);

        // キャンセルが要求されている場合
        if ( token.IsCancellationRequested )
        {
            Debug.Log ( "Canceled." );
            return;
        }
        
        // されていない場合
        Debug.Log("pool格納");
        // オブジェクトプールに回収
        tmpObj.objectPoolCallBack?.Invoke(tmpObj);
    }
}
