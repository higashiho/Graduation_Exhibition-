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
                        tmpEnemy.LightEnemy.enabled = false;
                        tmpEnemy.LeftEnemy.enabled = true;
                        
                    }
                    else if(tmpEnemy.EnemyMoveFlags == BaseEnemy.EnemyMoveFlag.RIGHT)
                    {
                        tmpEnemy.LeftEnemy.enabled = false;
                        tmpEnemy.LightEnemy.enabled = true;
                    }
                        break;
                default:
                        break;
}
        }
    }
}