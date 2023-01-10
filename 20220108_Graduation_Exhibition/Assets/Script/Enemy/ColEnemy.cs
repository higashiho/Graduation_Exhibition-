using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColEnemy : MonoBehaviour
{
    [SerializeField]
    private EnemyController enemy;
    // 当たり判定
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Wall")
        {
            // エネミーのムーブフラグを逆転
            if(enemy.EnemyMoveFlags == BaseEnemy.EnemyMoveFlag.LEFT)
                enemy.EnemyMoveFlags = BaseEnemy.EnemyMoveFlag.RIGHT;
            else
                enemy.EnemyMoveFlags = BaseEnemy.EnemyMoveFlag.LEFT;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Wall")
        {
            // エネミーのムーブフラグを逆転
            if(enemy.EnemyMoveFlags == BaseEnemy.EnemyMoveFlag.LEFT)
                enemy.EnemyMoveFlags = BaseEnemy.EnemyMoveFlag.RIGHT;
            else
                enemy.EnemyMoveFlags = BaseEnemy.EnemyMoveFlag.LEFT;
        }
    }
    
}
