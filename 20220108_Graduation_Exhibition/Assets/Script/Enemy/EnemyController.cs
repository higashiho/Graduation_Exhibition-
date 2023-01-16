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

        private PoliceAnimation animationPolice = new PoliceAnimation();
        // Start is called before the first frame update
        void Start()
        {
            StartPos = this.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if(InGameSceneController.Player.PlayerStatus != Player.BasePlayer.PlayerState.WARP)
                enemyUpdate();
        }
        
        // 挙動関数
        private void enemyUpdate()
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
                    if(!targetRenderer.isVisible)
                    // 画面外に出たらステート初期化
                    moveEnemy.StatusReset(this);

                    break;
                // プレイヤーとの座標変更時
                case EnemyState.CHANGE:
                    moveEnemy.VelocityClear(this);
                    break;
                    
                default:
                    break;
            }

            animationPolice.PoliceRightMoveSprite(this);
        }
        
    }
}