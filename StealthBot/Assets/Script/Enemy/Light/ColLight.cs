using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

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
                enemyLight.RetryPanel.DOFade(Const.MAX_ALPHA, Const.FADE_TIME).SetEase(Ease.Linear).
                OnStart(() =>InGameSceneController.Player.PlayerStatus = BasePlayer.PlayerState.RETRY).
                OnComplete(() => 
                {
                    BaseUI.HaveItem = default;
                    SceneManager.LoadScene(enemyLight.NowScene);
                });
            }
        }
    }
}