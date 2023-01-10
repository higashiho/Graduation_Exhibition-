using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Bullet
{
    public class BulletController : BaseBullet
    {   
        // 表示時処理
        private async void OnEnable()
        {
            await BulletMove.MoveBullet.Callback(this, bulletData, cts.Token);
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}