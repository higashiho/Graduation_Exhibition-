using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Enemy
{
    public class EnemyController : BaseEnemy
    {
        // インスタンス化
        private EnemyAttack attackEnemy = new EnemyAttack();
        private EnemyMove moveEnemy = new EnemyMove();
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
                    moveEnemy.Move(this);
                    break;
                // 攻撃挙動
                case EnemyState.ATTACK:
                    attackEnemy.Attack(this, bullet);
                    break;
                // プレイヤーとの座標変更時
                case EnemyState.CHANGE:
                    moveEnemy.VelocityClear(this);
                    break;
                default:
                    break;
            }
        }
        
        // 画面外に出た処理
        private void OnBecameInvisible()
        {
            // 画面外に出たらステート初期化
            moveEnemy.StatusReset(this);
        }
    }
}