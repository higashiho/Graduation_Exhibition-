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
            var tmpEnemyPos = tmpEnemy.MoveEnemy.distanse(tmpEnemy);

            switch(tmpEnemy.EnemysStatus)
            {
                case BaseEnemy.EnemyState.MOVE:             //右移動と左移動の切り替え
                    if(tmpEnemy.EnemyMoveFlags == BaseEnemy.EnemyMoveFlag.LEFT)
                    {
                        tmpEnemy.transform.eulerAngles = new Vector3(0, 180, 0);
                    }
                    else if(tmpEnemy.EnemyMoveFlags == BaseEnemy.EnemyMoveFlag.RIGHT)
                        tmpEnemy.transform.eulerAngles = new Vector3(0, 0, 0);
                        break;

                // case BaseEnemy.EnemyState.ATTACK:           //攻撃アニメーション
                //     if(tmpEnemyPos >= 0)
                //         tmpEnemy.PoliceAnm.Play("RightAttack");
                //     else
                //         tmpEnemy.PoliceAnm.Play("LeftAttack");
                //         break;
                default:
                        break;
}
        }
    }
}