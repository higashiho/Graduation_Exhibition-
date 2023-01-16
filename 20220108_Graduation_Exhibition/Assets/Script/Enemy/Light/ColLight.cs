using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace EnemyLight
{
    public class ColLight : MonoBehaviour
    {
        [SerializeField]
        private BaseLight enemyLight;
        // 当たり判定
        private void OnTriggerEnter2D(Collider2D other)
        {
            // プレイヤーとの当たり判定
            if(other.gameObject.tag == "Player" && InGameSceneController.Player.PlayerStatus != BasePlayer.PlayerState.WARP)
            {
                // 自身を消してエネミーの配列のどれかを呼び出す
                var tmpNum = UnityEngine.Random.Range(0, InGameSceneController.Enemys.Length);

                InGameSceneController.Enemys[tmpNum].transform.position =  this.gameObject.transform.position;
                this.gameObject.SetActive(false);
            }
        }
    }
}