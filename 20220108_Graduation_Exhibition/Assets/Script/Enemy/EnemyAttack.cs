using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet;


namespace Enemy
{
    public class EnemyAttack
    {

        public void Attack(BaseEnemy tmpEnemy, BaseBullet tmpBullet)
        {
            // 弾生成
            CreatBullet.BulletCreate.Move(tmpEnemy, tmpBullet);

            // 視界削除
            // 非アクティブ確認
            if(tmpEnemy.LeftVision.activeSelf || tmpEnemy.RightVision.activeSelf)
            {
                // アクティブの場合非アクティブにする
                tmpEnemy.LeftVision.SetActive(false);
                tmpEnemy.RightVision.SetActive(false);
            }
        }
    }
}
