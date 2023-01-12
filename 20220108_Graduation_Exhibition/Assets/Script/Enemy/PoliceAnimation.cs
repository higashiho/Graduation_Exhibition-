using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class PoliceAnimation
    {
        //アニメーションに切り替えと再生
        private void policeRightMoveSprite(BaseEnemy tmpEnemy)
        {
            switch(enemyStatus)
            {
                // 移動挙動
                case EnemyState.MOVE:
                    
                    break;
                // 攻撃挙動
                case EnemyState.ATTACK:
                    
                    break;
                // プレイヤーとの座標変更時
                case EnemyState.CHANGE:
                    
                    break;
                default:
                    break;
            }
            tmpEnemy.PoliceRightMoveAnm.enabled = true;
        }
    }
}