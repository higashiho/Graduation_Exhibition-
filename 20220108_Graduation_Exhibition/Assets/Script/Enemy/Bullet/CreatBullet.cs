using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks; 
using System.Threading;
using Enemy;
using Audio;

namespace Bullet
{
    public class CreatBullet
    {
        
        public static CreatBullet BulletCreate{get;private set;} = new CreatBullet();

        // トランプを打てるかフラグ
        private bool shotFlag = true;

        
        // 弾の生成と移動向きを代入する関数
        public async void Move(BaseEnemy tmpObj, BaseBullet tmpBulet)
        {
            if(shotFlag)
            {
                //エネミー攻撃音   
                //BaseAudio.audioSource.PlayOneShot(InGameSceneController.AudioInstance.EnemyAttack);
                shotFlag = false;
                // 生成
                BaseBullet clone = InGameSceneController.BulletObjectPool.Launch(tmpObj.transform.position, InGameSceneController.BulletObjectPool.BulletList, tmpBulet);

                // プレイヤーの座標
                Vector3 targetPos = InGameSceneController.Player.transform.position;

                // 向きの生成（Z成分の除去と正規化）
                clone.ShotForward = Vector3.Scale((targetPos - tmpObj.transform.position), new Vector3(1, 1, 0)).normalized;

                // トランプの挙動
                BulletMove.MoveBullet.Move(clone);

                await shotCoolTime(tmpBulet.BulletsData);
            }
        }

        // nミリ秒後にshotフラグを初期化
        private async UniTask shotCoolTime(BulletData bulletData)
        {
            await UniTask.Delay(bulletData.ShotTime * Const.CHANGE_SECOND);

            shotFlag = true;
        }
    }
}
