using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class PoliceAnimation
    {
        //アニメーションに切り替えと再生
        public void PoliceRightMoveSprite(BaseEnemy tmpEnemy)
        {
            switch(tmpEnemy.EnemysStatus)
            {
                case BaseEnemy.EnemyState.MOVE:             //右移動と左移動の切り替え
                    if(tmpEnemy.EnemyMoveFlags == BaseEnemy.EnemyMoveFlag.LEFT)
                    {
                        tmpEnemy.PoliceLeftMoveAnm.Play("LeftMove");
                    }
                    else if(tmpEnemy.EnemyMoveFlags == BaseEnemy.EnemyMoveFlag.RIGHT)
                        tmpEnemy.PoliceLeftMoveAnm.Play("Default");
                        
                        break;

                case BaseEnemy.EnemyState.ATTACK:           //攻撃アニメーション
                    if(tmpEnemy.EnemysStatus == BaseEnemy.EnemyState.ATTACK);
                        
                        break;
                default:
                        break;
}
        }
    }
}