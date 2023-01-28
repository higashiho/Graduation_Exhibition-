using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;


namespace Vision
{
    public class ColVision : MonoBehaviour
    {
        [SerializeField]    // 親オブジェクト
        private BaseEnemy enemy;
        // 当たり判定
        private void OnTriggerEnter2D(Collider2D other)
        {
            // プレイヤーのステートがワープではないとき
            if(other.gameObject.tag == "Player" && InGameSceneController.Player.PlayerStatus != Player.BasePlayer.PlayerState.WARP)
            {
                Detection();
            }
        }

        // 親オブジェのエネミーのステートを攻撃に変更
        private void Detection()
        {
            enemy.EnemysStatus = BaseEnemy.EnemyState.ATTACK;
            //エネミーがプレイヤー見つけた時の音
            InGameSceneController.AudioInstance.audioSource.PlayOneShot(InGameSceneController.AudioInstance.EnemyFound);
        }
    }
}
