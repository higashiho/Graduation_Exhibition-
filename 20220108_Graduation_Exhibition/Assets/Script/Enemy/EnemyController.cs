using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : BaseEnemy
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(enemyStatus)
        {
            // 移動挙動
            case EnemyState.MOVE:
                EnemyMove.MoveEnemy.Move(this);
                break;
            // 攻撃挙動
            case EnemyState.ATTACK:
                EnemyAttack.AttackEnemy.Attack(this, bullet);
                break;
            // プレイヤーとの座標変更時
            case EnemyState.CHANGE:
                EnemyMove.MoveEnemy.VelocityClear(this);
                break;
            default:
                break;
        }
    }
    
    // 画面外に出た処理
    private void OnBecameInvisible()
    {
        // 画面外に出たらステート初期化
        EnemyMove.MoveEnemy.StatusReset(this);
    }
}
