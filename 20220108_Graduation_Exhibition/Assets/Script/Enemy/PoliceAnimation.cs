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
                        tmpEnemy.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = tmpEnemy.LeftEnemy;
                        
                    }
                    else if(tmpEnemy.EnemyMoveFlags == BaseEnemy.EnemyMoveFlag.RIGHT)
                    {
                        tmpEnemy.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = tmpEnemy.RightEnemy;
                    }
                        break;
                default:
                        break;
}
        }
    }
}